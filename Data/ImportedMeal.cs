namespace livestockProject.Data
{
    public class ImportedMeal
    {
        public decimal Id { get; set; }
        public string MealName { get; set; } = null!;
        public string Origincountry { get; set; } = null!;
        public decimal Grossweight { get; set; }
        public decimal Netweight { get; set; }
        public decimal Count { get; set; }
        public string Livestocktype { get; set; } = null!;
        public DateTime Shippingdate { get; set; }
        public DateTime Shipmentarrivaldate { get; set; }
        public string Status { get; set; } = null!;
    }
}
