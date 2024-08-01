namespace livestockProject.Data
{
    public class Countries
    {
        public decimal Id { get; set; }

        public string NameArabic { get; set; } = null!;
        public string? NameEnglish { get; internal set; }
    }
}
