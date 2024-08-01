using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace livestockProject.Models
{
    public partial class SystemLivestockType
    {
        [Key]
        public int Id { get; set; }
        public string NameArabic { get; set; } = null!;
    }
}
