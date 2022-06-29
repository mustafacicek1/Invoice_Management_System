namespace Entities.DTOs
{
    public class ApartmentListDTO
    {
        public int Id { get; set; }
        public char Blok { get; set; }
        public string Type { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNo { get; set; }
        public bool IsEmpty { get; set; }
        public string? User { get; set; }
    }
}
