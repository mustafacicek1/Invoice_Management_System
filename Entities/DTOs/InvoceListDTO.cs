namespace Entities.DTOs
{
    public class InvoceListDTO
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal DuesPrice { get; set; }
        public decimal InvoicePrice { get; set; }
        public string User { get; set; }
    }
}
