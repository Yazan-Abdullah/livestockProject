using livestockProject.Models;
using System.Diagnostics.Metrics;

namespace livestockProject
{
    public class MealCountryLifestockTypeViewModel
    {
        public Importedmeal importedmeal  { get; set; }
        public IEnumerable<SystemCountry> Countries { get; set; }
        public IEnumerable<SystemLivestockType> livestockTypes  { get; set; }


    }
    

}
