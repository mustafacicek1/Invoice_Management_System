namespace Entities.Concrete
{
    public class Apartment
    {
        public int Id { get; set; }
        public char Blok { get; set; }
        public string Type { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
        public bool IsEmpty { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}
