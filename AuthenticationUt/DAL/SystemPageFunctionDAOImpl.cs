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
    public class SystemPageFunctionDAOImpl : SystemPageFunctionDAO
    {
        public List<SystemPageFunction> getSystemPageFunctionListByFunctionUID(int functionUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string filter = "";

                if (functionUID > 0)
                {
                    filter = "WHERE fp.FunctionUID ='"+ functionUID + "' ";
                }

                String sql = "SELECT fp.PageUID,p.Name,fp.FunctionUID,f.Name FROM RoleSystemFunctionPage fp " +
                    "INNER JOIN SystemFunction f ON fp.FunctionUID = f.FunctionUID " +
                    "INNER JOIN SystemPage p ON fp.PageUID = p.PageUID "+ filter;

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemPageFunction> systemPageFunctionList = new List<SystemPageFunction>();
                while (dataReader.Read())
                {
                    SystemPageFunction systemPageFunction = new SystemPageFunction(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetString(3));
                    systemPageFunctionList.Add(systemPageFunction);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return systemPageFunctionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addSystemPageFunction(int functionUID, SystemPage systemPage, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO RoleSystemFunctionPage(FunctionUID,PageUID,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) Values " +
                    "('" + functionUID + "','" + systemPage.systemPageUID + "','1','" + userName + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userName + "') ";

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

        public void deleteSystemPageByFunctionUID(int functionUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "DELETE RoleSystemFunctionPage WHERE FunctionUID =  '" + functionUID + "' ";

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
    }
}
