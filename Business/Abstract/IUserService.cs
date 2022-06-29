using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<UserListDTO> GetUsers();

        User GetUser(int userId);
        void CreateUser(CreateUserDTO createUserDTO);
        LoginResultDTO VerifyUser(LoginDTO loginDTO);
        void UpdateUser(int userId,UpdateUserDTO updateUserDTO);
        void DeleteUser(int userId);
    }
}
