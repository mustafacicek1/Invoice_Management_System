namespace CreditCardService.Models
{
    public class CreditCardDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CreditCardCollectionName { get; set; } = null!;
    }
}
