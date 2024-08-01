using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace livestockProject.DAL
{
    public class DB_UTIL
    {
        public OracleConnection Con;
        public OracleCommand Cmd;
        public OracleTransaction Trans;
        public string configPath;
        private bool disposed = false;
        private readonly IConfiguration _configuration;
        public DataSet ExecuteDataSet(string CmdText)
        {
            try
            {
                DataSet ds = new DataSet();
                if (string.IsNullOrEmpty(CmdText))
                    return ds;
                OracleDataAdapter Adaptergrid;
                Adaptergrid = new OracleDataAdapter(CmdText, Con);
                Adaptergrid.SelectCommand.CommandType = CommandType.Text;
                this.OpenConnection();
                Adaptergrid.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.CloseConnection();
                this.Dispose();
                GC.Collect();
            }
        }
        public bool ExceuteTrans(string Sql)
        {
            bool ss = true;
            using (OracleCommand oraCmd = new OracleCommand(Sql, new OracleConnection(configPath)))
            {
                oraCmd.CommandType = CommandType.Text;
                try
                {
                    oraCmd.BindByName = true;
                    oraCmd.Connection.Open();
                    oraCmd.ExecuteNonQuery();
                    return ss;
                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
                finally
                {
                    oraCmd.Connection.Close();
                }

            }
            return ss;
        }
        public string InsertUpdateGetID(string Sql, string Param)
        {
            string ss = "0";
            using (OracleCommand oraCmd = new OracleCommand(Sql, new OracleConnection(configPath)))
            {
                oraCmd.CommandType = CommandType.Text;
                try
                {
                    oraCmd.BindByName = true;
                    oraCmd.Connection.Open();
                    oraCmd.Parameters.Add(new OracleParameter
                    {
                        ParameterName = Param,
                        OracleDbType = OracleDbType.Int32,
                        Direction = ParameterDirection.Output
                    });
                    oraCmd.ExecuteNonQuery();
                    ss = oraCmd.Parameters[Param].Value.ToString();
                    return ss;
                }
                catch (Exception ex)
                {
                    return ss;
                    throw ex;
                }
                finally
                {
                    oraCmd.Connection.Close();
                }
            }
            return ss;
        }
        public void CommitTransaction()
        {
            try
            {
                this.Trans.Commit();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void OpenConnection()
        {
            try
            {
                if (Con.State == ConnectionState.Open) Con.Close();
                Con.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Con.State == ConnectionState.Open) Con.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Con != null)
                    {
                        this.Con.Dispose();
                        this.Cmd.Dispose();
                    }
                }
                disposed = true;
            }
        }
        public DB_UTIL()
        {
            try
            {
                _configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
                //
                Con = new OracleConnection();
                Cmd = new OracleCommand();
                configPath = _configuration.GetConnectionString("OracleConnection");//ConfigurationManager.ConnectionStrings["ConStrWings"].ToString();//"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=192.168.0.25)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=WORCL)));User Id=WSBackup;Password=WSBackup";
                Con.ConnectionString = configPath;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetUserGroupName(string groupID, string lang)
        {
            if (string.IsNullOrEmpty(groupID))
                return "";

            DataSet ds = new DataSet();
            string Sql = "select NAME_AR , nvl(NAME_EN,NAME_AR) NAME_EN from SYSTEM_USER_GROUP where id = " + groupID;
            ds = ExecuteDataSet(Sql);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (lang == "ar")
                        return ds.Tables[0].Rows[0]["NAME_AR"] + "";
                    else
                        return ds.Tables[0].Rows[0]["NAME_EN"] + "";
                }
            }
            return "";
        }
        public string GetMaxTable(string TableName, string IdName)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT nvl(MAX(" + IdName + "),0)+1 AS ID FROM " + TableName;
            ds = ExecuteDataSet(sql);
            return ds.Tables[0].Rows[0]["ID"] + "";
        }
        public bool DeleteTrans(string Sql)
        {
            bool ss = true;
            using (OracleCommand oraCmd = new OracleCommand(Sql, new OracleConnection(configPath)))
            {
                oraCmd.CommandType = CommandType.Text;
                try
                {
                    oraCmd.BindByName = true;
                    oraCmd.Connection.Open();
                    oraCmd.ExecuteNonQuery();
                    return ss;
                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
                finally
                {
                    oraCmd.Connection.Close();
                }
            }
            return ss;
        }
        ~DB_UTIL()
        {
            Con = null;
            Trans = null;
            Cmd = null;
            configPath = null;

        }
    }
}
