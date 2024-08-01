using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace livestockProject.Models
{
    public partial class SysModuel
    {
        public SysModuel()
        {
            SystemMenus = new HashSet<SystemMenu>();
        }

        [Key]
        public int Id { get; set; }
        public string DescAr { get; set; } = null!;
        public string DescEn { get; set; } = null!;
        public int? IsActive { get; set; }
        public string Moduleicon { get; set; } = null!;
        public string Moduleiconen { get; set; } = null!;

        public virtual ICollection<SystemMenu> SystemMenus { get; set; }
    }
}
