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
    public class RoleFunctionsDAOImpl: RoleFunctionsDAO
    {
        public void saveRoleFuntions(int roleUID, SystemFunction selectedFunction, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO RoleSystemFunction(RoleUID,FunctionUID,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + roleUID + "','" + selectedFunction.systemFunctionUID + "','" + userName + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userName + "') ";

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

        public void deleteRoleFuntions(int roleUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "Delete RoleSystemFunction WHERE RoleUID ='" + roleUID + "' ";

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

        public List<RoleSystemFuntion> getRoleFunctionListByRole(int roleUID)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string filter = "";
                if (roleUID != -1)
                {
                    filter = " WHERE rf.RoleUID = '"+roleUID+"' ";
                }

                String sql = "SELECT rf.RoleUID,r.Name,rf.FunctionUID,f.Name FROM RoleSystemFunction rf " +
                    "INNER JOIN Role r ON rf.RoleUID = r.RoleUID " +
                    "INNER JOIN SystemFunction f on rf.FunctionUID = f.FunctionUID "+ filter;

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<RoleSystemFuntion> roleSystemFuntionList = new List<RoleSystemFuntion>();

                while (dataReader.Read())
                {
                    RoleSystemFuntion roleSystemFuntion = new RoleSystemFuntion();
                    roleSystemFuntion.roleUID = dataReader.GetInt32(0);
                    roleSystemFuntion.roleName = dataReader.GetString(1);
                    roleSystemFuntion.functionUID = dataReader.GetInt32(2);
                    roleSystemFuntion.functionName = dataReader.GetString(3);
                    roleSystemFuntionList.Add(roleSystemFuntion);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return roleSystemFuntionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
