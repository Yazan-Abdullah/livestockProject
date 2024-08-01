using livestockProject.DAL;
using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace livestockProject.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();

            return View();
        }
       
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var loginResponse = new LoginResponse();
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM SYSTEM_USERS WHERE  Username = '" + Username + "' AND UPassword ='"+ Password+"'";
            ds = db_UTIL.ExecuteDataSet(sql);
            if(ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["IS_ACTIVE"] + "" == "0")
                    {
                        loginResponse.ErrorMessage = "Your account is not Active please call the admin";
                        return Json(loginResponse);
                    }
                    string updateSql = "UPDATE SYSTEM_USERS SET LAST_LOGIN_DATE = SYSDATE WHERE ID = " + ds.Tables[0].Rows[0]["ID"];
                    db_UTIL.ExceuteTrans(updateSql);
                    Fillsessions(ds);
                    loginResponse.Redirect = Url.Action("Index", "Home");
                }
                else
                {
                    loginResponse.ErrorMessage = "Error";
                }
            }
            else
            {
                loginResponse.ErrorMessage = "Wrong Username or Password";
            }
            return Json(loginResponse);
        }

        private void Fillsessions(DataSet UserDs)
        {
            UserSeesion user = new UserSeesion();
            foreach (DataRow row in UserDs.Tables[0].Rows)
            {
                user.Id = row["ID"] + "";
                user.Username = row["USERNAME"] + "";
                user.NameAr = row["NAME_ARABIC"] + "";
                user.NameEn = row["NAME_ENGLISH"] + "";
                user.UserGroupId = row["USER_GROUP_ID"] + "";
            }

            string userJson = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("User", userJson);
        }

        public class UserSeesion
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string NameAr { get; set; }
            public string NameEn { get; set; }
            public string UserGroupId { get; set; }

        }

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

    }
}
