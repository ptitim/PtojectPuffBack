using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DataAccess.DAO;
using DataAccess.Entity;
using DataAccess.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Service.DTO;

namespace Service.Service
{
    public class UserService
    {
        private UserManager<User> userManager { get; set; }
        
        private UserDao userDao { get; set; }


        public UserService(UserManager<User> userManager, IUserDao userDao)
        {
            this.userManager = userManager;
            this.userDao = new UserDao();
        }

        public async Task<UserDto> RegisterNewUser(UserDto dto)
        {

            // Check if basic data for regisration are filled
            if (!dto.HaveBasicData())
            {
                return null;
            }

            // test if mail already exist
            var user = userDao.GetUserByMail(dto.Email);
            if (user != null)
            {
                return null;
            }

            UserDto newUserDto;
            
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                
                // create the new user
                User newUser = UserDto.Populate(dto, null , salt.ToString() );
                userDao.CreateUser(newUser);

                userDao.SaveChanges();

                newUserDto = UserDto.Extract(newUser);
                await userManager.CreateAsync(newUser, newUser.Password);
                
            }

            return newUserDto;

        }
    }
}