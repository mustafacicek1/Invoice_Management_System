using CreditCardService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CreditCardService.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<CreditCard> _collection;
        public PaymentService(IOptions<CreditCardDbSettings> creditCardDbSettings)
        {
            var mongoClient = new MongoClient(
            creditCardDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                creditCardDbSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<CreditCard>(
                creditCardDbSettings.Value.CreditCardCollectionName);
        }

        public async Task<List<CreditCard>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<CreditCard?> GetByUserIdAsync(int id) =>
        await _collection.Find(x => x.UserId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CreditCard creditCard) =>
            await _collection.InsertOneAsync(creditCard);

        public async Task UpdateAsync(string id, CreditCard creditCard) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, creditCard);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public bool Pay(CreditCard creditCard, InvoiceModel invoiceModel)
        {
            var calculate = Calculate(creditCard, invoiceModel);
            if (calculate)
            {
                decimal totalPrice = invoiceModel.InvoicePrice + invoiceModel.DuesPrice;
                creditCard.RemainingBalance -= totalPrice;
                return true;
            }
            return false;
        }

        private bool Calculate(CreditCard creditCard,InvoiceModel invoiceModel)
        {
            decimal totalPrice = invoiceModel.InvoicePrice + invoiceModel.DuesPrice;
            if (creditCard.RemainingBalance >= totalPrice)
            {
                return true;
            }
            return false;
        }
    }
}
