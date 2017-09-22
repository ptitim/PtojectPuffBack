using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entity;

namespace Service.DTO
{
    public class UserDto
    {
        public int Id { get; private set; }
        
        public string Pseudo { get; private set; }
        
        public string Email { get; private set; }
        
//        public string Password { get; private set; }
        
//        public string Roles { get; private set; }



        public static UserDto Extract(User entity)
        {
            var dto = new UserDto();

            if (entity == null) return dto;

            dto.Id = entity.Id;
            dto.Email = entity.Email;
            dto.Pseudo = entity.Pseudo;

            return dto;

        }

//        public static User Populate(UserDto dto, User entity = null)
//        {
//            
//            
//        }
    }
    
    
}