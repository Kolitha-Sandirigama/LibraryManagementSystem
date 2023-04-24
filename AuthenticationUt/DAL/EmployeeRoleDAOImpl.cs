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
    public class EmployeeRoleDAOImpl: EmployeeRoleDAO
    {
        public List<EmployeeRole> getAllEmployeeRoles()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT e.EmployeeUID,e.EmployeeID,e.FirstName,e.LastName,r.RoleUID,r.Name,er.IsActive FROM EmployeeSystemRole er " +
                    "INNER JOIN Employee e On er.EmployeeUID = e.EmployeeUID INNER JOIN Role r ON er.RoleUID = r.RoleUID";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<EmployeeRole> employeeRoleList = new List<EmployeeRole>();
                while (dataReader.Read())
                {
                    EmployeeRole employeeRole  = new EmployeeRole(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetBoolean(6));
                    employeeRoleList.Add(employeeRole);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return employeeRoleList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void addEmployeeRole(EmployeeRole employeeRole, string userID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO EmployeeSystemRole(EmployeeUID,RoleUID,IsActive,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy) Values " +
                    "('" + employeeRole.employeeUID + "','" + employeeRole.roleUID + "','" + employeeRole.isActive + "','" + userID + "','" + DateTime.Now + "','" + DateTime.Now + "','" + userID + "') ";

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

        public void updateEmployeeRole(EmployeeRole employeeRole, string userID)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE EmployeeSystemRole SET IsActive = '"+ employeeRole .isActive+ "',LastModifiedDate = '" + DateTime.Now + "',LastModifiedBy = '" + userID + "' WHERE EmployeeUID = '"+ employeeRole .employeeUID+ "' AND RoleUID = '"+ employeeRole .roleUID+ "' ";                    

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

        public bool isEmployeeRoleExists(EmployeeRole employeeRole)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT count(EmployeeUID) FROM EmployeeSystemRole WHERE EmployeeUID = '" + employeeRole.employeeUID+"' AND RoleUID = '"+employeeRole.roleUID+"' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                bool isExists = false;        
                while (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) > 0)
                    {
                        isExists = true;
                    }
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return isExists;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
