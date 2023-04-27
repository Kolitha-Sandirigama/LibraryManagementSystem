using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.DAL
{
    public class FunctionDAOImpl : FunctionDAO
    {

        public List<Functions> GetUserFunctionCodeList(string UserCode)
        {
            try
            {

                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection conLinq = new SqlConnection(connetionString);
                conLinq.Open();

                String sql = "SELECT f.FunctionUID,f.Name " +
                    "FROM RoleSystemFunction rf " +
                    "INNER JOIN SystemFunction f ON rf.FunctionUID = f.FunctionUID " +
                    "INNER JOIN EmployeeSystemRole er ON rf.RoleUID = er.RoleUID " +
                    "INNER JOIN Employee e ON er.EmployeeUID = e.EmployeeUID " +
                    "INNER JOIN UserLogin u ON e.EmployeeUID = u.EmployeeUID " +
                    "WHERE u.UserName = '" + UserCode + "' AND rf.IsActive = '1' AND f.IsActive = '1' AND er.IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, conLinq);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Functions> functionsList = new List<Functions>();
                while (dataReader.Read())
                {
                    Functions function = new Functions();
                    function.FunctionUID = dataReader.GetInt32(0);
                    function.FunctionName = dataReader.GetString(1);
                    functionsList.Add(function);

                }
                dataReader.Close();
                command.Dispose();
                conLinq.Close();


                return functionsList;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetFunctionCodeByPageName(string pageName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection conLinq = new SqlConnection(connetionString);
                conLinq.Open();

                String sql = "SELECT fp.FunctionUID FROM RoleSystemFunctionPage fp " +
                    "INNER JOIN SystemPage p ON fp.PageUID = p.PageUID WHERE p.URL = '" + pageName + "'";

                SqlCommand command = new SqlCommand(sql, conLinq);
                SqlDataReader dataReader = command.ExecuteReader();
                int functionUID = 0;


                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        functionUID = dataReader.GetInt32(0);
                    }
                }
                dataReader.Close();
                command.Dispose();
                conLinq.Close();

                return functionUID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
