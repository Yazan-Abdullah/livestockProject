using DBL;
using livestockProject.DAL;
using livestockProject.Data;
using livestockProject.DTO;
using livestockProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace livestockProject.Controllers
{
    public class ImportedMealController : Controller
    {
        public IConfiguration Configuration { get; }

        public ImportedMealController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            try
            {
                string sqlQuery = "SELECT * FROM IMPORTEDMEAL ORDER BY ID ASC";
                ds = db_UTIL.ExecuteDataSet(sqlQuery);
                if (ds.Tables.Count > 0)
                {
                    List<ImportedMeal> importedMeals = new List<ImportedMeal>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ImportedMeal importedMeal = new ImportedMeal
                        {
                            Id = (decimal)row["ID"],
                            MealName = (string)row["MEAL_NAME"],
                            Origincountry = (string)row["ORIGINCOUNTRY"],
                            Grossweight = (decimal)row["GROSSWEIGHT"],
                            Netweight = (decimal)row["NETWEIGHT"],
                            Count = (decimal)row["COUNT"],
                            Livestocktype = (string)row["LIVESTOCKTYPE"],
                            Shippingdate = (DateTime)row["SHIPPINGDATE"],
                            Shipmentarrivaldate = (DateTime)row["SHIPMENTARRIVALDATE"],
                            Status = (string)row["STATUS"]
                        };
                        importedMeals.Add(importedMeal);
                    }
                    return View(importedMeals);
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


        public IActionResult AddMealView()
        {
            try
            {
                var countries = GetCountries();
                var livestockTypes = GetLivestockTypes();

                ViewBag.countries = new SelectList(countries, "Id", "NameArabic");
                ViewBag.LivestockType = new SelectList(livestockTypes, "Id", "NameArabic");

                return View();
            }
            catch (Exception ex)
            {
                return Problem("An error occurred: " + ex.Message);
            }
        }

        private List<Countries> GetCountries()
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();
            List<Countries> countries = new List<Countries>();

            string countrySqlQuery = "SELECT ID, NAME_ARABIC FROM SYSTEM_COUNTRY";

            DataSet countryDataSet = db_UTIL.ExecuteDataSet(countrySqlQuery);

            if (countryDataSet.Tables.Count > 0)
            {
                    foreach (DataRow row in countryDataSet.Tables[0].Rows)
                    {
                        Countries country = new Countries
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            NameArabic = row["NAME_ARABIC"].ToString(),
                        };
                        countries.Add(country);
                    }
            }
            

            return countries;
        }

        private List<LivestockType> GetLivestockTypes()
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            List<LivestockType> livestockTypes = new List<LivestockType>();
            string livestockTypeSqlQuery = "SELECT ID, NAME_ARABIC FROM SYSTEM_LIVESTOCK_TYPE";
          
            DataSet livestockTypeDataSet = db_UTIL.ExecuteDataSet(livestockTypeSqlQuery);

                if (livestockTypeDataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in livestockTypeDataSet.Tables[0].Rows)
                    {
                        LivestockType livestockType = new LivestockType
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            NameArabic = row["NAME_ARABIC"].ToString(),
                        };
                        livestockTypes.Add(livestockType);
                    }
                }
   
            return livestockTypes;
        }
        
        [HttpPost]
        public IActionResult AddMeal(AddMealDTO mealDto)
        {
            DB_UTIL db_UTIL = new DB_UTIL();
            DataSet ds = new DataSet();

            if (!ModelState.IsValid)
            {
                return Json(new { status = "error", message = "Invalid model state" });
            }
            ImportedMeal meal = new ImportedMeal
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
                string sqlQuery = "INSERT INTO IMPORTEDMEAL (MEAL_NAME, ORIGINCOUNTRY, GROSSWEIGHT, NETWEIGHT, COUNT, LIVESTOCKTYPE, SHIPPINGDATE, SHIPMENTARRIVALDATE, STATUS) " +
                                  "VALUES (:MealName, :Origincountry, :Grossweight, :Netweight, :Count, :Livestocktype, :Shippingdate, :Shipmentarrivaldate, :Status)";
                                     
                    using (OracleCommand oraCmd = new OracleCommand(sqlQuery, db_UTIL.Con))
                    {
                        oraCmd.CommandType = CommandType.Text;
                        
                        oraCmd.Parameters.Add(new OracleParameter(":MealName", OracleDbType.Varchar2) { Value = meal.MealName });
                        oraCmd.Parameters.Add(new OracleParameter(":Origincountry", OracleDbType.Varchar2) { Value = meal.Origincountry });
                        oraCmd.Parameters.Add(new OracleParameter(":Grossweight", OracleDbType.Decimal) { Value = meal.Grossweight });
                        oraCmd.Parameters.Add(new OracleParameter(":Netweight", OracleDbType.Decimal) { Value = meal.Netweight });
                        oraCmd.Parameters.Add(new OracleParameter(":Count", OracleDbType.Int32) { Value = meal.Count });
                        oraCmd.Parameters.Add(new OracleParameter(":Livestocktype", OracleDbType.Varchar2) { Value = meal.Livestocktype });
                        oraCmd.Parameters.Add(new OracleParameter(":Shippingdate", OracleDbType.Date) { Value = meal.Shippingdate });
                        oraCmd.Parameters.Add(new OracleParameter(":Shipmentarrivaldate", OracleDbType.Date) { Value = meal.Shipmentarrivaldate });
                        oraCmd.Parameters.Add(new OracleParameter(":Status", OracleDbType.Varchar2) { Value = meal.Status });
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
                return Json(new { status = "error", message = "Error with database operation: " + ex.Message });
            }
        }

        public Importedmeal GetMealById(int Id)
        {
            Importedmeal Imported = new Importedmeal();
            using (OracleConnection con = new OracleConnection("User Id=livestock;Password=livestock;Data Source=192.168.0.25:1521/worcl;"))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from IMPORTEDMEAL where Id=" + Id + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Importedmeal IMP = new Importedmeal
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            MealName = rdr["MealName"].ToString(),
                            Origincountry = rdr["Origincountry"].ToString(),
                            Grossweight =(int)rdr["Grossweight"],
                            Netweight = (int)rdr["Netweight"],
                            Count = (int)rdr["Count"],
                            Livestocktype = rdr["Livestocktype"].ToString(),
                            Shippingdate = (DateTime)rdr["Shippingdate"],
                            Shipmentarrivaldate = (DateTime)rdr["Shipmentarrivaldate"],
                            Status = rdr["Status"].ToString()
                        };
                    Imported = IMP;
                    }
                }
            }
            return Imported;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            string connectionString = "User Id=livestock;Password=livestock;Data Source=192.168.0.25:1521/worcl;"; 
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Teacher WHERE Id = :Id";
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(new OracleParameter("Id", OracleDbType.Int32)).Value = id;
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ViewBag.Result = "Record deleted successfully.";
                        }
                        else
                        {
                            ViewBag.Result = "No records found with the specified ID.";
                        }
                    }
                    catch (OracleException ex)
                    {
                        ViewBag.Result = "Operation got an error: " + ex.Message;
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
