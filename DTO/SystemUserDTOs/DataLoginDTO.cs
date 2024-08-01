namespace Livestock.DTO.AccountDTOs
{
    public class DataLoginDTO
    {
        public DataLoginDTO()
        {
            UserInfo = new UserInfo();
        }
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
        public UserInfo UserInfo { get; set; }
    }
    public class UserInfo
    {
        public string Id { get; set; }
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserGroupId { get; set; }
        public string LastLoginDate { get; set; }
        public string LastChangePassword { get; set; }
        public bool? IsActive { get; set; }
    }
}
