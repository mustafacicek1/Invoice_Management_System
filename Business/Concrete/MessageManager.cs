using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MessageManager:IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<MessageListDTO> MessageList()
        {
            var messages = _unitOfWork.Messages.GetAll();
            var vm = _mapper.Map<List<MessageListDTO>>(messages);
            return vm;
        }

        public void SendMessage(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            _unitOfWork.Messages.Add(message);
            _unitOfWork.SaveChanges();
        }
    }
}
