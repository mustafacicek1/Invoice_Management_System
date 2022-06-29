using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.AutoMapper.Profiles
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageDTO, Message>();
            CreateMap<Message, MessageListDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
