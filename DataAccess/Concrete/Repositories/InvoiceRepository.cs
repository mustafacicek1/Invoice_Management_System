using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {

        }
    }
}
