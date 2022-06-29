using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>,IPaymentRepository
    {
        public PaymentRepository(DbContext context) : base(context)
        {

        }
    }
}
