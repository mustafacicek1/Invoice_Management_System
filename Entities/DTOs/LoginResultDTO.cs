namespace Entities.DTOs
{
    public class LoginResultDTO
    {
        public bool Success { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
    }
}
