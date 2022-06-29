using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void SendMessage(CreateMessageDTO createMessageDTO);
        List<MessageListDTO> MessageList();
    }
}
