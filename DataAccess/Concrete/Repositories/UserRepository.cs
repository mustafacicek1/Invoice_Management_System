using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
