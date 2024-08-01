using System;
using System.Collections.Generic;

namespace livestockProject.Models
{
    public partial class SystemUserGroup
    {
        public SystemUserGroup()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        public int UserGroupId { get; set; }
        public int? MenuId { get; set; }
        public string? NameAr { get; set; }
        public string NameEn { get; set; } = null!;

        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
