namespace livestockProject.Models.ImportedMealModel
{
    public class ImportedmealDataTable
    {
        public int CountAllRows { get; set; }
        public List<ImportedmealM> Data { get; set; }
    }
    public class ImportedmealM
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Origincountry { get; set; }
        public double Grossweight { get; set; }
        public double Netweight { get; set; }
        public int Count { get; set; }
        public string Livestocktype { get; set; }
        public DateTime Shippingdate { get; set; }
        public DateTime Shipmentarrivaldate { get; set; }
        public string Status { get; set; }
    }


    public class ImportedmealDetailsM
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Origincountry { get; set; }
        public double Grossweight { get; set; }
        public double Netweight { get; set; }
        public int Count { get; set; }
        public string Livestocktype { get; set; }
        public DateTime Shippingdate { get; set; }
        public DateTime Shipmentarrivaldate { get; set; }
        public string Status { get; set; }
    }
}
