using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace livestockProject.Controllers
{
    public class ImportedMealController : Controller
    {
        private readonly livestockContext _context;
        public ImportedMealController(livestockContext context)
        {
            _context = context;
        }


        
        public IActionResult Index()
        {
            return _context.Importedmeals != null ?
                          View(_context.Importedmeals.ToList()) :
                          Problem("Entity set 'LMSContext.ImportedMeal'  is null.");
           
        }

        public IActionResult AddMealVeiw()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMeal(AddMealDTO mealDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = "error", message = "Invalid model state" });
            }

            var meal = new Importedmeal
            {
                MealName = mealDto.MealName,
                Origincountry = mealDto.Origincountry,
                Grossweight = mealDto.Grossweight,
                Netweight = mealDto.Netweight,
                Count = mealDto.Count,
                Livestocktype = mealDto.Livestocktype,
                Shippingdate = mealDto.Shippingdate,
                Shipmentarrivaldate = mealDto.Shipmentarrivaldate,
                Status = mealDto.Status
            };

            try
            {
                _context.Importedmeals.Add(meal);
                await _context.SaveChangesAsync();
                return Json(new { status = "success", message = "Meal added successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Error adding the meal: " + ex.Message });
            }
        }
        public async Task<IActionResult> EditMeal()
        {
            return View();
        }
    }
}
