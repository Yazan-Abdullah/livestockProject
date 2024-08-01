using livestockProject.DAL;
using livestockProject.Data;
using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace livestockProject.Controllers
{
    public class SystemCountryController : Controller
    {
        
        public IActionResult Index()
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            try
            {
                string sqlQuery = "SELECT * FROM SYSTEM_COUNTRY ORDER BY ID ASC";
                ds = db_UTIL.ExecuteDataSet(sqlQuery);
                if (ds.Tables.Count > 0)
                {
                    List<Countries> countries = new List<Countries>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Countries country = new Countries
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            NameArabic = row["NAME_ARABIC"].ToString(),
                            NameEnglish = row["NAME_ENGLISH"].ToString(),
                        };
                        countries.Add(country);
                    }
                    return View(countries);
                }
                else
                {
                    return Problem("No data found in 'ImportedMeals' table.");
                }
            }
            catch (Exception ex)
            {
                return Problem("An error occurred: " + ex.Message);
            }

            
        }
        [HttpGet]
        public IActionResult AddCountry()
        {

            return View();
        }
        [HttpPost]
       
        public IActionResult CreateCountry(string NameArabic,string NameEnglish)
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            if (!ModelState.IsValid)
            {
                return Json(new { status = "error", message = "Invalid model state" });
            }
            try
            {
                Countries country = new Countries
                {
                    NameArabic = NameArabic
                };
                 string sql = "INSERT INTO SYSTEM_COUNTRY (NAME_ARABIC,NAME_ENGLISH) VALUES (:NameArabic)";
                using (OracleCommand oraCmd = new OracleCommand(sql, db_UTIL.Con))
                {
                    oraCmd.CommandType = CommandType.Text;
                    oraCmd.Parameters.Add(new OracleParameter(":MealName", OracleDbType.Varchar2) { Value = NameArabic });
                    oraCmd.Parameters.Add(new OracleParameter(":MealName", OracleDbType.Varchar2) { Value = NameEnglish });
                    try
                    {
                        db_UTIL.OpenConnection();
                        oraCmd.ExecuteNonQuery();
                        return Json(new { status = "success", message = "Meal added successfully" });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { status = "error", message = "Error adding the meal: " + ex.Message });
                    }
                }
                
            }
            catch (Exception ex)
            {
                // Consider logging the exception for further debugging
                return Json(new { status = "error", message = "Error creating the country." });
            }
        }

       
        [HttpPost]
        public IActionResult DeleteCountry(decimal id)
        {
            string connectionString = "User Id=livestock;Password=livestock;Data Source=192.168.0.25:1521/worcl;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From SYSTEM_COUNTRY Where ID='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Index");
        }
        

    }
}