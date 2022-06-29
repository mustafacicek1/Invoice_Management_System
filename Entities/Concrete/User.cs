namespace Entities.Concrete
{
    public class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Apartments = new HashSet<Apartment>();
            Invoices = new HashSet<Invoice>();
            Payments = new HashSet<Payment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? CarNumberPlate { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
