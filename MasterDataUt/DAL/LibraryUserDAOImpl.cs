using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class LibraryUserDAOImpl: LibraryUserDAO
    {
        public List<LibraryUser> findByAll()
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.LibraryUserUID,e.LibraryUserID,e.FirstName,e.LastName,e.NIC,e.IsActive,e.LibraryUserCategoryUID,ISNULL(LUC.Name,'') " +
                    "FROM LibraryUser e Left OUTER JOIN LibraryUserCategory LUC ON e.LibraryUserCategoryUID = LUC.LibraryUserCategoryUID ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<LibraryUser> LibraryUserList = new List<LibraryUser>(); ;
                while (dataReader.Read())
                {
                    LibraryUser libraryUser = new LibraryUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetString(7));
                    libraryUser.userFullName = dataReader.GetString(1) + "_" + dataReader.GetString(2) + "_" + dataReader.GetString(3);
                    LibraryUserList.Add(libraryUser);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return LibraryUserList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<LibraryUser> findByActiveAll()
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.LibraryUserUID,e.LibraryUserID,e.FirstName,e.LastName,e.NIC,e.IsActive,e.LibraryUserCategoryUID,LUC.Name " +
                    "FROM LibraryUser e INNER JOIN LibraryUserCategory LUC ON e.LibraryUserCategoryUID = LUC.LibraryUserCategoryUID WHERE e.IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<LibraryUser> libraryUserList = new List<LibraryUser>(); ;
                while (dataReader.Read())
                {
                    LibraryUser libraryUser = new LibraryUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetString(7));
                    libraryUser.userFullName = dataReader.GetString(1) + "_" + dataReader.GetString(2) + "_" + dataReader.GetString(3);
                    libraryUserList.Add(libraryUser);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();


                return libraryUserList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LibraryUser findByLibraryUserNIC(string NIC)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM LibraryUser WHERE NIC ='" + NIC + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                LibraryUser libraryUser = null;
                while (dataReader.Read())
                {
                    libraryUser = new LibraryUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetString(7));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return libraryUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void addLibraryUser(LibraryUser libraryUser, string loginUSerName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO LibraryUser(LibraryUserID,FirstName,LastName,NIC,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate,LibraryUserCategoryUID) VALUES " +
                    "('" + libraryUser.userID + "','" + libraryUser.firstName + "','" + libraryUser.lastName + "','" + libraryUser.NIC + "','" + loginUSerName + "','" + DateTime.Now + "','" + loginUSerName + "','" + DateTime.Now + "','"+libraryUser.LibraryUserCategoryUID+"') ";

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

        public int getLibraryUserUIDByAll(LibraryUser libraryUser)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM LibraryUser WHERE LibraryUserID ='" + libraryUser.userID + "' AND FirstName ='" + libraryUser.firstName + "' AND LastName ='" + libraryUser.lastName + "' AND NIC ='" + libraryUser.NIC + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                int LibraryUserUID = 0;
                while (dataReader.Read())
                {
                    LibraryUserUID = dataReader.GetInt32(0);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return LibraryUserUID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void editLibraryUser(LibraryUser libraryUser, string loginUserName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE LibraryUser SET LibraryUserID = '" + libraryUser.userID + "',FirstName = '" + libraryUser.firstName + "',LastName = '" + libraryUser.lastName + "',NIC = '" + libraryUser.NIC + "',IsActive = '" + libraryUser.isActive + "',LastModifiedBy = '" + loginUserName + "',LastModifiedDate ='" + DateTime.Now + "',LibraryUserCategoryUID = '" + libraryUser.LibraryUserCategoryUID+"' " +
                            "WHERE  LibraryUserUID = " + libraryUser.userUID;

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

        public LibraryUser findByLibraryUserNICAndLibraryUserUID(int libraryUserUID, string NIC)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM LibraryUser WHERE NIC ='" + NIC + "' AND LibraryUserUID <>'" + libraryUserUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                LibraryUser libraryUser = null;
                while (dataReader.Read())
                {
                    libraryUser = new LibraryUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetString(7));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return libraryUser;
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


                String sql = "SELECT ISNULL(MAX(LibraryUserUID),0) FROM LibraryUser ";

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

        public int getTotalActiveUserCount()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT COUNT(LibraryUserUID) FROM LibraryUser WHERE ISACTIVE = '1' ";

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
