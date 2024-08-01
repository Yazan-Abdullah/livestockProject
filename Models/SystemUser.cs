using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace livestockProject.Models
{
    public partial class SystemUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string NameArabic { get; set; } = null!;
        public string NameEnglish { get; set; } = null!;
        public string Upassword { get; set; } = null!;
        public int UserGroupId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastChangePassword { get; set; }
        public bool? IsActive { get; set; }

        public virtual SystemUserGroup UserGroup { get; set; } = null!;
    }
}
