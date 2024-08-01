namespace livestockProject.Models.SystemCountryModel
{
    public class SystemCountryDataTable
    {
        public int CountAllRows { get; set; }
        public List<SystemCountryM> Data { get; set; }
    }
    public class SystemCountryM
    {
        public int Id { get; set; }
        public string NameArabic { get; set; }
    }


    public class SystemCountryDetailsM
    {
        public int? Id { get; set; }
        public string NameArabic { get; set; }
    }
}
