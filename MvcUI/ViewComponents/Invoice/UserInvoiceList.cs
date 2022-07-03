using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcUI.ViewComponents.Invoice
{
    public class UserInvoiceList:ViewComponent
    {
        private readonly IInvoiceService _invoiceService;
        public UserInvoiceList(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IViewComponentResult Invoke()
        {
            string? id = HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(id);
            var invoices = _invoiceService.GetInvocesByUserId(userId);
            return View(invoices);
        }
    }
}
