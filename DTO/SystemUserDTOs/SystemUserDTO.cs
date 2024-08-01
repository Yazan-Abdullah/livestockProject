namespace Livestock.DTO.SystemUserDTOs
{
    public class SystemUserDTO
    {
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal UserGroupId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public int CountAllRows { get; set; }
        public bool? IsActive { get; set; }
    }
}
