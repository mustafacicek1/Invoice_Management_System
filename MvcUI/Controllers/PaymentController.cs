using Business.Abstract;
using Business.APIServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly CreditCardService _creditCardService;
        private readonly IInvoiceService _invoiceService;
        public PaymentController(IPaymentService paymentService,
            CreditCardService creditCardService,
            IInvoiceService invoiceService)
        {
            _paymentService = paymentService;
            _creditCardService = creditCardService;
            _invoiceService = invoiceService;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = _paymentService.PaymentList();
            return View(payments);
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Pay(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            var paymentInfo = await _creditCardService.Pay(invoice);
            if (paymentInfo !=null)
            {
                _paymentService.AddPayment(paymentInfo);
                return RedirectToAction("GetMyInvoices", "Invoice");
            }
            return RedirectToAction("GetMyInvoices", "Invoice");
        }
    }
}
