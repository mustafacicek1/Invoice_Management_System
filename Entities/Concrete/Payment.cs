namespace Entities.Concrete
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }

        public Invoice Invoice { get; set; }
        public User User { get; set; }
    }
}
