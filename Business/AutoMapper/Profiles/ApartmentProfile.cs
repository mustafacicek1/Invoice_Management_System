using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper.Profiles
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<CreateApartmentDTO, Apartment>();
            CreateMap<Apartment, ApartmentListDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom
                (src => src.User == null ? null : src.User.Name));
        }
    }
}
