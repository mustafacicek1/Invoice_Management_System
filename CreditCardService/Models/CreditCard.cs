using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditCardService.Models
{
    public class CreditCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}
