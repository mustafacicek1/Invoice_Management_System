namespace Entities.DTOs
{
    public class PaymentListDTO
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string InvoiceMonth { get; set; }
        public string User { get; set; }
    }
}
