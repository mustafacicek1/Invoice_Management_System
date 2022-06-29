namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IApartmentRepository Apartments {get;}
        IInvoiceRepository Invoices {get;}
        IMessageRepository Messages {get;}
        IPaymentRepository Payments {get;}
        IUserRepository Users {get;}
        int SaveChanges();
    }
}
