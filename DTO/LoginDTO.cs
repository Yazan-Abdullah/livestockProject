namespace livestockProject.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime LastLoginDate { get; set; }
    }
}
 