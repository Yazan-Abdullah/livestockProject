using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace livestockProject.Models
{
    public partial class SystemMenu
    {
        [Key]
        public int Id { get; set; }
        public string MenunameAr { get; set; } = null!;
        public string MenunameEn { get; set; } = null!;
        public string? SystemFunction { get; set; }
        public string? Menuorder { get; set; }
        public bool? MenuFlag { get; set; }
        public string Createduser { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedUser { get; set; } = null!;
        public DateTime? LastUpdateDate { get; set; }
        public int? ModuleId { get; set; }
        public string? MenuController { get; set; }
        public string? MenuView { get; set; }
        public int? PerantId { get; set; }

        public virtual SysModuel? Module { get; set; }
    }
}
