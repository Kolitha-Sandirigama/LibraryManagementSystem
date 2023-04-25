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
    public class BorrowingBooksDAOImpl : BorrowingBooksDAO
    {
        public List<BookBorrowingRecord> findByAll() 
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT R.BookBorrowingRecordUID,R.BookUID,B.Name,R.UserUID,L.LibraryUserID,R.ReturnDate,R.isActive,B.ISBNNo " +
                    "FROM BookBorrowingRecord R " +
                    "INNER JOIN Book B On R.BookUID = B.BookUID " +
                    "INNER JOIN LibraryUser L ON R.UserUID = L.LibraryUserUID " +
                    "WHERE R.isActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<BookBorrowingRecord> BookBorrowingRecordList = new List<BookBorrowingRecord>(); ;
                while (dataReader.Read())
                {
                    BookBorrowingRecord bookBorrowingRecord = new BookBorrowingRecord(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetDateTime(5), dataReader.GetBoolean(6), dataReader.GetString(7));
                    BookBorrowingRecordList.Add(bookBorrowingRecord);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return BookBorrowingRecordList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addBorrowingBookRecord(BookBorrowingRecord bookBorrowingRecord, String UserID) 
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "INSERT INTO BookBorrowingRecord(BookUID,UserUID,ReturnDate,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + bookBorrowingRecord.bookUID + "','" + bookBorrowingRecord.userUID + "','" + bookBorrowingRecord.returnDate + "','True','" + UserID + "','" + DateTime.Now + "','" + DateTime.Now + "','" + UserID + "') ";

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


        public void updateBorrowingBookRecord(BookBorrowingRecord bookBorrowingRecord, String UserID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "UPDATE Book SET IsAvailable = 'False' WHERE BookUID = '" + bookBorrowingRecord.bookUID + "' ";
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

        public bool checkIsBookAvailableByBookUID(int bookUID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT BookUID FROM Book WHERE IsAvailable = 'True' AND BookUID = '" + bookUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                bool isAvailable = false;
                while (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) > 0) 
                    {
                        isAvailable = true;
                    }
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return isAvailable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
