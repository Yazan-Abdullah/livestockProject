using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace livestockProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly livestockContext _context;
        public UsersController(livestockContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return _context.SystemUsers != null ?
                          View(_context.SystemUsers.ToList()) :
                          Problem("Entity set 'LMSContext.Users'  is null.");

        }

        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserDTO addUserDto)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
                return Json(new { status = "error", message = "Invalid data provided.", errors = modelErrors });
            }

            var user = new SystemUser
            {
                Username = addUserDto.Username,
                NameArabic = addUserDto.NameArabic,
                NameEnglish = addUserDto.NameEnglish,
                Password = addUserDto.Password,
                Groupid = addUserDto.Groupid,
                LastLoginDate = addUserDto.LastLoginDate,
                LastChangePassword = addUserDto.LastChangePassword,
                IsActive = addUserDto.IsActive
            };

            try
            {
                _context.SystemUsers.Add(user);
                await _context.SaveChangesAsync();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                // Consider logging the exception for further debugging
                return Json(new { status = "error", message = "Error creating the user." });
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Toggle the IsActive value
            user.IsActive = !user.IsActive;

            _context.Update(user);
            await _context.SaveChangesAsync();

            TempData["UserUpdateMessage"] = (bool)user.IsActive ?
                "User status updated to Active." :
                "User status updated to Inactive.";

            return RedirectToAction("Index", "Users");
        }



    }
}
