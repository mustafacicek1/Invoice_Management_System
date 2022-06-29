using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper.Profiles
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<CreateInvoiceDTO, Invoice>();
            CreateMap<Invoice, InvoceListDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
