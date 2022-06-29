namespace Entities.Concrete
{
    public class Invoice
    {
        public Invoice()
        {
            Payments = new HashSet<Payment>();
        }
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal DuesPrice { get; set; }
        public decimal InvoicePrice { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
