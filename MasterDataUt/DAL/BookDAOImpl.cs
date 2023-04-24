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
    public class BookDAOImpl : BookDAO
    {
        public List<Book> findByAll()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.BookUID,e.BookID,e.Name,e.Author,e.ISBNNo,e.IsActive,e.bookCategoryUID,ISNULL(LUC.Name,'') " +
                    "FROM Book e Left OUTER JOIN BookCategory LUC ON e.bookCategoryUID = LUC.BookCategoryUID ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Book> BookList = new List<Book>(); ;
                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6));
                    BookList.Add(book);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return BookList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addBook(Book book, string loginUSerName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO Book(BookID,Name,Author,ISBNNo,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate,bookCategoryUID) VALUES " +
                    "('" + book.bookID + "','" + book.Name + "','" + book.Author + "','" + book.ISBNNo + "','" + loginUSerName + "','" + DateTime.Now + "','" + loginUSerName + "','" + DateTime.Now + "','" + book.bookCategoryUID + "') ";

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

        public Book findByBookISBN(string isbnNo)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM Book WHERE ISBNNo ='" + isbnNo + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                Book book = null;
                while (dataReader.Read())
                {
                    book = new Book(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getBookUIDByAll(Book book)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM Book WHERE BookID ='" + book.bookID + "' AND Name ='" + book.Name + "' AND Author ='" + book.Author + "' AND ISBNNo ='" + book.ISBNNo + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                int bookUID = 0;
                while (dataReader.Read())
                {
                    bookUID = dataReader.GetInt32(0);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return bookUID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void editBook(Book book, string loginUSerName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE Book SET BookID = '" + book.bookID + "',Name = '" + book.Name + "',Author = '" + book.Author + "',ISBNNo = '" + book.ISBNNo + "',IsActive = '" + book.isActive + "',LastModifiedBy = '" + loginUSerName + "',LastModifiedDate ='" + DateTime.Now + "',bookCategoryUID = '" + book.bookCategoryUID + "' " +
                            "WHERE  BookUID = " + book.bookUID;

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

        public Book findByBookISBNAndBookUID(int BookUID, string ISBN)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM BOOK WHERE ISBNNo ='" + ISBN + "' AND BookUID <>'" + BookUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                Book book = null;
                while (dataReader.Read())
                {
                    book = new Book(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Book> findByActiveAll()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.BookUID,e.BookID,e.Name,e.Author,e.ISBNNo,e.IsActive,e.bookCategoryUID,ISNULL(LUC.Name,'') " +
                    "FROM Book e Left OUTER JOIN BookCategory LUC ON e.bookCategoryUID = LUC.BookCategoryUID WHERE e.IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Book> BookList = new List<Book>(); ;
                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6));
                    BookList.Add(book);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return BookList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getNextSequenceNo()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT ISNULL(MAX(BookUID),0) FROM Book ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                int maxID = 0;

                while (dataReader.Read())
                {
                    maxID = dataReader.GetInt32(0);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return maxID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
