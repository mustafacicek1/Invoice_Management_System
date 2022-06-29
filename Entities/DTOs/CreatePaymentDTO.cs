namespace Entities.DTOs
{
    public class CreatePaymentDTO
    {
        public decimal TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
    }
}
