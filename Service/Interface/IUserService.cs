using DataAccess.DAO;
using DataAccess.Entity;
using Service.DTO;

namespace Service.Interface
{
    public interface IUserService : IBaseDao
    {
        UserDto RegisterNewUser(UserDto userDto);
    }
}