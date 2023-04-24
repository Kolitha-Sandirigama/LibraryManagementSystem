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
    public class BookCategoryDAOImpl: BookCategoryDAO
    {
        public List<BookCategory> getAllBookCategories()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT BookCategoryUID,Name,Description,IsActive FROM BookCategory ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<BookCategory> bookCategoryList = new List<BookCategory>();

                while (dataReader.Read())
                {
                    BookCategory bookCategory = new BookCategory(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    bookCategoryList.Add(bookCategory);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return bookCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addBookCategory(BookCategory bookCategory, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "INSERT INTO BookCategory(Name,Description,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + bookCategory.description + "','" + bookCategory.notes + "','" + bookCategory.isActive + "','" + userName + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userName + "') ";

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

        public void updateBookCategory(BookCategory bookCategory, string userName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE BookCategory SET Description = '" + bookCategory.notes + "',IsActive = '" + bookCategory.isActive + "',LastModifiedDate = '" + DateTime.Now + "',LastModifiedBy = '" + userName + "' " +
                    "WHERE BookCategoryUID ='" + bookCategory.bookCategoryUID + "' ";

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

        public bool checkIsExistsByBookCategoryName(string bookCategoryName)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                String sql = "SELECT count(BookCategoryUID) FROM BookCategory WHERE NAME ='" + bookCategoryName + "'  ";

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

        public List<BookCategory> getActiveBookCategoryList() 
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "SELECT BookCategoryUID,Name,Description,IsActive FROM BookCategory WHERE IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader dataReader = command.ExecuteReader();
                List<BookCategory> bookCategoryList = new List<BookCategory>();

                while (dataReader.Read())
                {
                    BookCategory bookCategory = new BookCategory(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetBoolean(3));
                    bookCategoryList.Add(bookCategory);
                }

                dataReader.Close();
                command.Dispose();
                con.Close();

                return bookCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
