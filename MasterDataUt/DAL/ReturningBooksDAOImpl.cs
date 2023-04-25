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
    public class ReturningBooksDAOImpl : ReturningBooksDAO
    {
        public List<BookReturningRecord> findByAll()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT R.BookReturningRecordUID,R.BookUID,B.Name,R.UserUID,L.LibraryUserID,R.isActive,B.ISBNNo " +
                    "FROM BookReturningRecord R " +
                    "INNER JOIN Book B On R.BookUID = B.BookUID " +
                    "INNER JOIN LibraryUser L ON R.UserUID = L.LibraryUserUID " +
                    "WHERE R.isActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<BookReturningRecord> BookReturningRecordList = new List<BookReturningRecord>(); ;
                while (dataReader.Read())
                {
                    BookReturningRecord bookReturningRecord = new BookReturningRecord(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetString(6));
                    BookReturningRecordList.Add(bookReturningRecord);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return BookReturningRecordList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void addReturningBookRecord(BookReturningRecord bookReturningRecord, String UserID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "INSERT INTO BookReturningRecord(BookUID,UserUID,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) VALUES " +
                    "('" + bookReturningRecord.bookUID + "','" + bookReturningRecord.userUID + "','True','" + UserID + "','" + DateTime.Now + "','" + DateTime.Now + "','" + UserID + "') ";

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

        public void updateReturningBookRecord(BookReturningRecord bookReturningRecord, String UserID) 
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                string sql = "UPDATE Book SET IsAvailable = 'True' WHERE BookUID = '" + bookReturningRecord.bookUID + "' ";
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
