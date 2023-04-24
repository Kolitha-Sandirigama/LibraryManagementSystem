using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;


namespace AuthenticationUt.DAL
{
    public class SystemFunctionsDAOImpl: SystemFunctionsDAO
    {
        public List<SystemFunction> getAllFunctions()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT FunctionUID,Name,Description,IsActive FROM SystemFunction ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemFunction> systemFunctionList = new List<SystemFunction>();

                while (dataReader.Read())
                {
                    SystemFunction systemFunction = new SystemFunction(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    systemFunctionList.Add(systemFunction);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return systemFunctionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addFunction(SystemFunction systemFunction, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "INSERT INTO SystemFunction(Name,Description,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + systemFunction.description + "','" + systemFunction.notes + "','" + systemFunction.isActive + "','" + userName + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userName + "') ";

                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateFunction(SystemFunction systemFunction, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE SystemFunction SET Description = '" + systemFunction.notes + "',IsActive = '" + systemFunction.isActive + "',LastModifiedDate = '" + DateTime.Now + "',LastModifiedBy = '" + userName + "' " +
                    "WHERE FunctionUID ='"+ systemFunction .systemFunctionUID +"' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkIsExistsByFunctionName(string functionName )
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String sql = "SELECT count(FunctionUID) FROM SystemFunction WHERE NAME ='"+ functionName + "'  ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                bool isExist = false;

                while (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) > 0) 
                    {
                        isExist = true;
                    }
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return isExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SystemFunction> getAllFunctionListByRole(int roleUID)
        {
            try 
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT s.FunctionUID,s.Name,s.Description,s.IsActive FROM SystemFunction s " +
                    "LEFT OUTER JOIN RoleSystemFunction r ON s.FunctionUID = r.FunctionUID AND r.RoleUID = '"+roleUID+"' " +
                    "WHERE r.FunctionUID IS NULL";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemFunction> systemFunctionList = new List<SystemFunction>();

                while (dataReader.Read())
                {
                    SystemFunction systemFunction = new SystemFunction(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    systemFunctionList.Add(systemFunction);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return systemFunctionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SystemFunction> getSelectedFunctionListByRole(int roleUID)
        {
            try 
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT s.FunctionUID,s.Name,s.Description,s.IsActive FROM SystemFunction s " +
                    "INNER JOIN RoleSystemFunction r ON s.FunctionUID = r.FunctionUID WHERE r.RoleUID = '" + roleUID + "' ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemFunction> systemFunctionList = new List<SystemFunction>();

                while (dataReader.Read())
                {
                    SystemFunction systemFunction = new SystemFunction(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    systemFunctionList.Add(systemFunction);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return systemFunctionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SystemFunction> getSelectedFunctionList()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT s.FunctionUID,s.Name,s.Description,s.IsActive FROM SystemFunction s " ;

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemFunction> systemFunctionList = new List<SystemFunction>();

                while (dataReader.Read())
                {
                    SystemFunction systemFunction = new SystemFunction(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    systemFunctionList.Add(systemFunction);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return systemFunctionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
