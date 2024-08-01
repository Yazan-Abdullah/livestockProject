namespace livestockProject.Data
{
    public class LivestockType
    {
        public decimal Id { get; set; }
        public string NameArabic { get; set; } = null!;
        public string? NameEnglish { get; internal set; }
    }
}
