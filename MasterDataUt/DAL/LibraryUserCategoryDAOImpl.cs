using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public class LibraryUserCategoryDAOImpl : LibraryUserCategoryDAO
    {
        public List<LibraryUserCategory> getAllLibraryUserCategories()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT LibraryUserCategoryUID,Name,Description,IsActive FROM LibraryUserCategory ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<LibraryUserCategory> libraryUserCategoryList = new List<LibraryUserCategory>();

                while (dataReader.Read())
                {
                    LibraryUserCategory libraryUserCategory = new LibraryUserCategory(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    libraryUserCategoryList.Add(libraryUserCategory);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return libraryUserCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addLibraryUserCategory(LibraryUserCategory libraryUserCategory, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "INSERT INTO LibraryUserCategory(Name,Description,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + libraryUserCategory.description + "','" + libraryUserCategory.notes + "','" + libraryUserCategory.isActive + "','" + userName + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userName + "') ";

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

        public void updateLibraryUserCategory(LibraryUserCategory libraryUserCategory, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE LibraryUserCategory SET Description = '" + libraryUserCategory.notes + "',IsActive = '" + libraryUserCategory.isActive + "',LastModifiedDate = '" + DateTime.Now + "',LastModifiedBy = '" + userName + "' " +
                    "WHERE LibraryUserCategoryUID ='" + libraryUserCategory.libraryUserCategoryUID + "' ";

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

        public bool checkIsExistsByLibraryUserCategoryName(string libraryUserCategoryName)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String sql = "SELECT count(LibraryUserCategoryUID) FROM LibraryUserCategory WHERE NAME ='" + libraryUserCategoryName + "'  ";

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
    }
}
