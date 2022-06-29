namespace Entities.DTOs
{
    public class CreateInvoiceDTO
    {
        public string Month { get; set; }
        public decimal DuesPrice { get; set; }
        public decimal InvoicePrice { get; set; }
    }
}
