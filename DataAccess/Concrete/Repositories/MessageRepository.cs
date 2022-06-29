using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.Repositories
{
    public class MessageRepository : GenericRepository<Message>,IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {

        }
    }
}
