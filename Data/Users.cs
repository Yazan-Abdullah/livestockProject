using livestockProject.Models;

namespace livestockProject.Data
{
    public class Users
    {
        public decimal Id { get; set; }
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Upassword { get; set; } = null!;
        public decimal UserGroupId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public bool? IsActive { get; set; }
    }
}
