using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        List<InvoceListDTO> GetInvocesByUserId(int userId);
        Invoice GetInvoice(int invoiceId);
        void AddInvoice(CreateInvoiceDTO createInvoiceDTO);
        List<InvoceListDTO> GetDebtList();
    }
}
