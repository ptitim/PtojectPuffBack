using DataAccess.Entity;
using DataAccess.Interface;

namespace DataAccess.DAO
{
    public class UserDao : BaseDao, IUserDao
    {

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        /// <summary>
        /// Get user by mail
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public User GetUserByMail(string mail)
        {
            return context.Users.Find(mail);
        }
        
        /// <summary>
        /// Add a user to db context
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            context.Users.Add(user);
        }
        
        
    }
}