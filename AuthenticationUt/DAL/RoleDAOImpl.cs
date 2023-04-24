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
    public class RoleDAOImpl : RoleDAO
    {
        public void addRole(string roleName,bool isActive,string loginUserName) 
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO Role(Name,IsActive,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate) VALUES " +
                    "('" + roleName + "','"+ isActive + "','" + loginUserName + "','" + DateTime.Now + "','" + loginUserName + "','" + DateTime.Now + "') ";

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

        public void updateRole(int roleUID, string roleName, bool isActive, string loginUserName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE Role SET Name = '"+roleName+"',IsActive = '"+ isActive + "',LastModifiedBy = '"+loginUserName+"',LastModifiedDate = '"+DateTime.Now+"' WHERE RoleUID = '"+roleUID+"' ";

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

        public List<Role> getAllRole()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
            SqlConnection conLinq = new SqlConnection(connetionString);
            conLinq.Open();

            String sql = "SELECT RoleUID,Name,IsActive FROM Role";

            SqlCommand command = new SqlCommand(sql, conLinq);
            SqlDataReader dataReader = command.ExecuteReader();
            List<Role> roleList = new List<Role>();
            Role role = null;
            while (dataReader.Read())
            {
                role = new Role(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetBoolean(2));
                roleList.Add(role);
            }
            dataReader.Close();
            command.Dispose();
            conLinq.Close();

            return roleList;
        }

        public bool getIsExistByName(string roleName)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
            SqlConnection conLinq = new SqlConnection(connetionString);
            conLinq.Open();

            String sql = "SELECT Count(RoleUID) FROM Role where Name ='"+roleName.Trim().ToString()+"' ";

            SqlCommand command = new SqlCommand(sql, conLinq);
            SqlDataReader dataReader = command.ExecuteReader();
            int count = 0; 
            while (dataReader.Read())
            {
                if (dataReader.GetInt32(0) > 0)
                {
                    count++;
                }
            }
            dataReader.Close();
            command.Dispose();
            conLinq.Close();

            if (count > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        public bool getIsExistByNameAndUID(string roleName,int UID)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
            SqlConnection conLinq = new SqlConnection(connetionString);
            conLinq.Open();

            String sql = "SELECT Count(RoleUID) FROM Role where Name ='" + roleName.Trim().ToString()+"' AND RoleUID <> '"+UID+"' " ;

            SqlCommand command = new SqlCommand(sql, conLinq);
            SqlDataReader dataReader = command.ExecuteReader();
            int count = 0;
            while (dataReader.Read())
            {
                if (dataReader.GetInt32(0) > 0)
                {
                    count++;
                }
            }
            dataReader.Close();
            command.Dispose();
            conLinq.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Role> getAllActiveRole()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
            SqlConnection conLinq = new SqlConnection(connetionString);
            conLinq.Open();

            String sql = "SELECT RoleUID,Name,IsActive FROM Role WHERE IsActive = '1' ";

            SqlCommand command = new SqlCommand(sql, conLinq);
            SqlDataReader dataReader = command.ExecuteReader();
            List<Role> roleList = new List<Role>();
            Role role = null;
            while (dataReader.Read())
            {
                role = new Role(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetBoolean(2));
                roleList.Add(role);
            }
            dataReader.Close();
            command.Dispose();
            conLinq.Close();

            return roleList;
        }

    }
}
