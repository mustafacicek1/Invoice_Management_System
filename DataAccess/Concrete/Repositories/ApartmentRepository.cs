using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
