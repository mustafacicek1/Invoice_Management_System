namespace CreditCardService.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public decimal DuesPrice { get; set; }
        public decimal InvoicePrice { get; set; }
        public int UserId { get; set; }
    }
}
