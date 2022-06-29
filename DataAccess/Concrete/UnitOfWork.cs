using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ApartmentRepository _apartmentRepository;
        private InvoiceRepository _invoiceRepository;
        private MessageRepository _messageRepository;
        private PaymentRepository _paymentRepository;
        private UserRepository _userRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IApartmentRepository Apartments => _apartmentRepository ?? new ApartmentRepository(_context);

        public IInvoiceRepository Invoices => _invoiceRepository ?? new InvoiceRepository(_context);

        public IMessageRepository Messages => _messageRepository ?? new MessageRepository(_context);

        public IPaymentRepository Payments => _paymentRepository ?? new PaymentRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
