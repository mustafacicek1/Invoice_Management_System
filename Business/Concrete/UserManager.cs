using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateUser(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            user.Password = GetRandomPassword(8);
            user.Role = "User";
            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _unitOfWork.Users.Get(x => x.Id == userId);
            _unitOfWork.Users.Delete(user);
            _unitOfWork.SaveChanges();
        }

        public User GetUser(int userId)
        {
            var user = _unitOfWork.Users.Get(x => x.Id == userId);
            return user;
        }

        public List<UserListDTO> GetUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            return _mapper.Map<List<UserListDTO>>(users);
        }

        public void UpdateUser(int userId, UpdateUserDTO updateUserDTO)
        {
            var user = _unitOfWork.Users.Get(x => x.Id == userId);
            user.Email = updateUserDTO.Email;
            user.IdentificationNumber = updateUserDTO.IdentificationNumber;
            user.Name = updateUserDTO.Name;
            user.Phone = updateUserDTO.Phone;
            user.CarNumberPlate = updateUserDTO.CarNumberPlate;
            _unitOfWork.SaveChanges();
        }

        public LoginResultDTO VerifyUser(LoginDTO loginDTO)
        {
            var user = _unitOfWork.Users.Get(x => x.IdentificationNumber == loginDTO.IdentificationNumber
            && x.Password == loginDTO.Password);
            if (user != null)
            {
                return new LoginResultDTO { Success = true, UserRole = user.Role,UserId=user.Id };
            }
            return new LoginResultDTO { Success = false };
        }

        private string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
