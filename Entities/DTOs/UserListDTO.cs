namespace Entities.DTOs
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? CarNumberPlate { get; set; }
    }
}
