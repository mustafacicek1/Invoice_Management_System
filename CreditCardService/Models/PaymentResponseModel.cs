namespace CreditCardService.Models
{
    public class PaymentResponseModel
    {
        public decimal TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
    }
}
