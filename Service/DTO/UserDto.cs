using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataAccess.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Service.DTO
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        
        public string Pseudo { get; private set; }
        
        public string Email { get; private set; }
        
        public string Password { get; private set; }
        
        public DateTime? CreationDate { get; private set; }
        
        public bool? RemenberMe { get; private set; }
        
//        public string Roles { get; private set; }



        public static UserDto Extract(User entity)
        {
            var dto = new UserDto();

            if (entity == null) return dto;

            dto.Id = entity.Id;
            dto.Email = entity.Email;
            dto.Pseudo = entity.Pseudo;
            dto.CreationDate = entity.CreationDate;
            dto.RemenberMe = false;
            

            return dto;

        }

        public static User Populate(UserDto dto, User entity = null, string salt = null)
        {
            bool isnew = false;
            
            if (entity == null)
            {
                entity = new User();
                isnew = true;
            }

            if (isnew)
            {
                entity.CreationDate = DateTime.UtcNow;
                entity.Salt = salt;
                using (var sha = SHA256.Create())
                {
                    entity.Password = sha.ComputeHash(Encoding.UTF8.GetBytes(entity.Salt + entity.Password)).ToString();
                }
            }

            if (!string.IsNullOrEmpty(dto.Pseudo))
                entity.Pseudo = dto.Pseudo;

            if (dto.RemenberMe.HasValue)
                entity.RemenberMe = dto.RemenberMe.Value;


            if (!string.IsNullOrEmpty(dto.Email))
                entity.Email = dto.Email;


            return entity;
        }

        #region Methods

        public bool HaveBasicData()
        {
            var haveMail = !string.IsNullOrWhiteSpace(Email);
            var havePassword = !string.IsNullOrWhiteSpace(Password);
            var havePseudo = !string.IsNullOrWhiteSpace(Pseudo);

            return haveMail && havePassword && havePseudo;
        }

        

        #endregion
    }
    
    
}