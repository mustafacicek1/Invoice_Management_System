
namespace Entities.DTOs
{
    public class CreateApartmentDTO
    {
        public char Blok { get; set; }
        public string Type { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
        public bool IsEmpty { get; set; }
        public int? UserId { get; set; }
    }
}
