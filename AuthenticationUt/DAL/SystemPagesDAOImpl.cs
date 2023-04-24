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
    class SystemPagesDAOImpl: SystemPagesDAO
    {
        public void addSystemPage(SystemPage systemPage, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO SystemPage(Name,Description,URL,CreatedBy,CreatedDate) Values " +
                    "('" + systemPage.systemPageName + "','" + systemPage.description + "','" + systemPage.systemPageURL + "','" + userName + "','" + DateTime.Now + "') ";

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

        public List<SystemPage> getSystemPagesByAll()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT PageUID,Name,URL,Description FROM SystemPage";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemPage> SystemPageList = new List<SystemPage>();
                while (dataReader.Read())
                {
                    SystemPage SystemPage = new SystemPage(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                    SystemPageList.Add(SystemPage);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return SystemPageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SystemPage> getAllPageListByFuncionUID(int functionUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT p.PageUID,p.Name,p.URL,p.Description FROM SystemPage p " +
                    "LEFT OUTER JOIN RoleSystemFunctionPage rfp on p.PageUID = rfp.PageUID AND rfp.FunctionUID = '"+ functionUID + "' WHERE rfp.PageUID IS NULL";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemPage> SystemPageList = new List<SystemPage>();
                while (dataReader.Read())
                {
                    SystemPage SystemPage = new SystemPage(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                    SystemPageList.Add(SystemPage);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return SystemPageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SystemPage> getSelectedPageListByFuncionUID(int functionUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT p.PageUID,p.Name,p.URL,p.Description FROM SystemPage p " +
                    "INNER JOIN RoleSystemFunctionPage rfp on p.PageUID = rfp.PageUID WHERE rfp.FunctionUID = '" + functionUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<SystemPage> SystemPageList = new List<SystemPage>();
                while (dataReader.Read())
                {
                    SystemPage SystemPage = new SystemPage(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                    SystemPageList.Add(SystemPage);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return SystemPageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
