using DBL;
using livestockProject.DAL;
using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using static livestockProject.Controllers.AuthenticationController;

namespace livestockProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ModelContext _context;
        public UsersController(ModelContext context)
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
        public IActionResult UserViewbag()
        {
            List<SystemUser> Users = _context.SystemUsers.ToList();

            return View(Users);
           
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
                Upassword = addUserDto.Password,
                UserGroupId = (int)addUserDto.Groupid,
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


        public IActionResult UpdateUser(int id)
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            try
            {
                string selectSql = "SELECT IS_ACTIVE FROM SYSTEM_USERS WHERE ID = " + id;
                ds = db_UTIL.ExecuteDataSet(selectSql);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int isActiveValue = Convert.ToInt32(ds.Tables[0].Rows[0]["IS_ACTIVE"]);
                    int newIsActiveValue = (isActiveValue == 1) ? 0 : 1;

                    string updateSql = "UPDATE SYSTEM_USERS SET IS_ACTIVE = " + newIsActiveValue + " WHERE ID = " + id;
                    db_UTIL.ExceuteTrans(updateSql);

                    TempData["UserUpdateMessage"] = (newIsActiveValue == 1)
                        ? "User status updated to Active."
                        : "User status updated to Inactive.";

                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

       
        public ActionResult Delete(int id)
        {
            try
            {
                var result = DeleteData(id);
                return Json(result);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteData(int id)
        {
            try
            {
                RepositoryADO repositoryADO = new RepositoryADO();
                string sql = "DELETE FROM SYSTEM_USERS WHERE ID = '" + id + "'";
                bool result = repositoryADO.DeleteTrans(sql);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

    }
}
