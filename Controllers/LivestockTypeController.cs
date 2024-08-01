using Humanizer;
using livestockProject.DAL;
using livestockProject.Data;
using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace livestockProject.Controllers
{
    public class LivestockTypeController : Controller
    {
        private readonly ModelContext _context;
        public LivestockTypeController(ModelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            try
            {
                string sqlQuery = "SELECT * FROM SYSTEM_LIVESTOCK_TYPE ORDER BY ID ASC";
                ds = db_UTIL.ExecuteDataSet(sqlQuery);
                if (ds.Tables.Count > 0)
                {
                    List<LivestockType> livestockTypes = new List<LivestockType>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LivestockType livestockType = new LivestockType
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            NameArabic = row["NAME_ARABIC"].ToString(),
                            NameEnglish = row["NAME_ENGLISH"].ToString()
                        };
                        livestockTypes.Add(livestockType);
                    }
                    return View(livestockTypes);
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
        public IActionResult AddLifestockType()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateLifestockType(string NameArabic,string NameEnglish)
       {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(NameArabic))
            {
                return Json(new { status = "error", message = "Invalid data provided. NameArabic is required." });
            }
            try
            {            
                string sql = "INSERT INTO SYSTEM_LIVESTOCK_TYPE (NAME_ARABIC,NAME_ENGLISH) VALUES (:NameArabic,:NameEnglish)";
                string param = "p_livestock_id";
                using (OracleCommand oraCmd = new OracleCommand(sql, db_UTIL.Con))
                {
                    oraCmd.CommandType = CommandType.Text;
                    oraCmd.Parameters.Add(new OracleParameter(":NameArabic", OracleDbType.Varchar2) { Value = NameArabic });
                    oraCmd.Parameters.Add(new OracleParameter(":NameEnglish", OracleDbType.Varchar2) { Value = NameEnglish });
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
                return Json(new { status = "error", message = "Error creating the livestock type." });
            }
        }


        [HttpPost]
        public IActionResult DeleteLifestockType(int Id)
        {
            if (Id <= 0)
            {
                return Json(new { status = "error", message = "Invalid data provided. Id is required and should be a positive integer." });
            }

            string connectionString = "User Id=livestock;Password=livestock;Data Source=192.168.0.25:1521/worcl;";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("DELETE FROM SYSTEM_LIVESTOCK_TYPE WHERE ID = :Id", connection))
                {
                    command.Parameters.Add(new OracleParameter(":Id", OracleDbType.Int32, Id, ParameterDirection.Input));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Json(new { status = "success" });
                        }
                        else
                        {
                            return Json(new { status = "error", message = "No records were deleted. Please check if the provided Id exists." });
                        }
                    }
                    catch (Exception ex)
                    {
                        // Consider logging the exception for further debugging
                        return Json(new { status = "error", message = "Error deleting the livestock type." });
                    }
                }
            }
        }


    }
}
