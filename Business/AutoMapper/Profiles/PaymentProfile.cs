using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper.Profiles
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentListDTO>()
                .ForMember(dest=>dest.InvoiceMonth,opt=>opt.MapFrom(src=>src.Invoice.Month))
                .ForMember(dest=>dest.User,opt=>opt.MapFrom(src=>src.User.Name));

            CreateMap<CreatePaymentDTO, Payment>();
        }
    }
}
