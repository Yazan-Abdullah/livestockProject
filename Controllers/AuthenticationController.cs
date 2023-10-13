using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livestockProject.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly livestockContext _context;
        public AuthenticationController(livestockContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Username, string password)
        {
            var loginResponse = new LoginResponse();

            var user = await _context.SystemUsers.FirstOrDefaultAsync(x => x.Username == Username && x.Password == password);

            if (user != null)
            {
                var userToUpdate = await _context.SystemUsers.FindAsync(user.Id);

                userToUpdate.LastLoginDate = DateTime.Now;

                await _context.SaveChangesAsync();

                loginResponse.Redirect = Url.Action("Index", "Home");
            }
            else
            {
                loginResponse.ErrorMessage = "Wrong Username or Password";
            }

            return Json(loginResponse);
        }

        //[HttpPost]
        //public IActionResult Login(string Username, string password)
        //{
        //    var loginResponse = new LoginResponse();

        //    SystemUser user = _context.SystemUsers.FirstOrDefault(x => x.Username == Username && x.Password == password);

        //    if (user != null)
        //    {
        //        // Update the LastLoginDate for the existing user
        //        user.LastLoginDate = DateTime.Now;

        //        // Save the changes to the database
        //        _context.SaveChanges();

        //        loginResponse.Redirect = Url.Action("Index", "Home");
        //    }
        //    else
        //    {
        //        loginResponse.ErrorMessage = "Wrong Username or Password";
        //    }

        //    return Json(loginResponse);
        //}

        public class LoginResponse
        {
            public string Redirect { get; set; }
            public string ErrorMessage { get; set; }
        }

        [HttpGet]
        public IActionResult Logout()
        {         
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Authentication"); 
        }

        //var currentTime = DateTime.Now.ToString();
        //HttpContext.Session.SetString("LastVisit", currentTime);

        //var lastVisit = HttpContext.Session.GetString("LastVisit");
    }
}
