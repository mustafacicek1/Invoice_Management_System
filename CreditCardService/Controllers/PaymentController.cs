using CreditCardService.Models;
using CreditCardService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _paymentService.GetAsync();
            return Ok(cards);
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(CreditCard creditCard)
        {
            await _paymentService.CreateAsync(creditCard);

            return Created("", creditCard);
        }


        [HttpPost("pay")]
        public async Task<IActionResult> Pay(InvoiceModel invoiceModel)
        {
            var creditCard = await _paymentService.GetByUserIdAsync(invoiceModel.UserId);

            var payResult = _paymentService.Pay(creditCard, invoiceModel);

            if (payResult)
            {
                await _paymentService.UpdateAsync(creditCard.Id, creditCard);

                return Ok(new PaymentResponseModel {
                    InvoiceId = invoiceModel.Id,
                    PaymentDate =DateTime.Now,
                    TotalPrice =invoiceModel.InvoicePrice+invoiceModel.DuesPrice,
                    UserId = invoiceModel.UserId,
                });
            }

            return BadRequest();
        }
    }
}
