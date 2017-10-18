using DataAccess.Entity;

namespace DataAccess.Interface
{
    public interface IUserDao
    {

        User GetUserById(int id);

        User GetUserByMail(string mail);
        
        void CreateUser(User user);
        
    }
}