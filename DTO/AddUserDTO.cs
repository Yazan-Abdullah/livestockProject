namespace livestockProject.DTO
{
    public class AddUserDTO
    {
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Groupid { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public bool? IsActive { get; set; }
    }
}
