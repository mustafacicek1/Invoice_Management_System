using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, UserListDTO>();
        }
    }
}
