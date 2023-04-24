using System;
using System.Configuration;
using System.Data.SqlClient;
using AuthenticationUt.Domain;
using AuthenticationUt.Util;

namespace AuthenticationUt.DAL
{
    public class UserLoginDAOImpl : UserLoginDAO
    {
        public LoginUser findByUserLoginID(string userLoginID)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT ul.UserLoginUID,ul.UserName,ul.EmployeeUID,ul.IsActive " +
                    "FROM UserLogin ul " +
                    "INNER JOIN Employee e on ul.EmployeeUID = e.EmployeeUID WHERE ul.IsActive = '1' AND e.IsActive = '1' And ul.UserName ='" + userLoginID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                LoginUser userLogin = null;
                while (dataReader.Read())
                {
                    userLogin = new LoginUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetBoolean(3));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return userLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool checkUserLoginByPassword(LoginUser ulogin, string password)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                Encryption encryption = new Encryption();
                string pwd = encryption.GetEncryptedString(password);

                String sql = "SELECT UserLoginUID FROM UserLogin WHERE UserLoginUID ='" + ulogin.UserLoginID + " ' AND UserPassword = '" + pwd + " '";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                Boolean isExist = false;
                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        if (dataReader.GetInt32(0) > 0)
                        {
                            isExist = true;
                        }
                    }
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return isExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void addUserLogin(LoginUser user, string loginUSerName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                Encryption encryption = new Encryption();
                string pwd = encryption.GetEncryptedString("12345");

                String sql = "INSERT INTO UserLogin(UserName,UserPassword,EmployeeUID,IsActive,EnteredUserID,EnteredDate,LastModifiedUserID,LastModifiedDate) Values " +
                    "('" + user.UserName + "','" + pwd + "','" + user.EmployeeUID + "','1','" + loginUSerName + "','" + DateTime.Now + "','" + loginUSerName + "','" + DateTime.Now + "') ";

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

        public void updatePasswordByUserLogin(LoginUser userLogin, string password)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                Encryption encryption = new Encryption();
                string pwd = encryption.GetEncryptedString(password);

                String sql = "UPDATE UserLogin SET UserPassword = '" + pwd + "' WHERE UserName = '" + userLogin.UserName + "' AND EmployeeUID = '" + userLogin.EmployeeUID + "' ";

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
