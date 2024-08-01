using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace livestockProject.Models
{
    public partial class Importedmeal
    {
        [Key]
        public int Id { get; set; }
        public string MealName { get; set; } = null!;
        public string Origincountry { get; set; } = null!;
        public int Grossweight { get; set; }
        public int Netweight { get; set; }
        public int Count { get; set; }
        public string Livestocktype { get; set; } = null!;
        public DateTime Shippingdate { get; set; }
        public DateTime Shipmentarrivaldate { get; set; }
        public string Status { get; set; } = null!;
    }
}
