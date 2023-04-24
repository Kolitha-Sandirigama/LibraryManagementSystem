using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using System.Data.SqlClient;
//using Util;
using System.Configuration;

namespace AuthenticationUt.DAL
{
    public class EmployeeDAOImpl : EmployeeDAO
    {
        public List<Employee> findByAll()
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.EmployeeUID,e.EmployeeID,e.FirstName,e.LastName,e.NIC,e.IsActive FROM Employee e " +
                             "INNER JOIN UserLogin ul " +
                             "ON e.EmployeeUID = ul.EmployeeUID WHERE ul.IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Employee> employeeList = new List<Employee>(); ;
                List<Employee> employeeListAll = new List<Employee>(); ;
                while (dataReader.Read())
                {
                    Employee employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5));
                    employee.employeeIDName = dataReader.GetString(1)+"_"+ dataReader.GetString(2)+"_"+dataReader.GetString(3);
                    employeeList.Add(employee);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();

                foreach (Employee emp in employeeList)
                {
                    emp.addUserLogin(this.getUserLoginByEmloyee(emp));
                    employeeListAll.Add(emp);
                }

                return employeeListAll;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Employee> findByActiveAll()
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "SELECT e.EmployeeUID,e.EmployeeID,e.FirstName,e.LastName,e.NIC,e.IsActive FROM Employee e " +
                             "WHERE e.IsActive = '1' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Employee> employeeList = new List<Employee>(); ;
                while (dataReader.Read())
                {
                    Employee employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5));
                    employee.employeeIDName = dataReader.GetString(1) + "_" + dataReader.GetString(2) + "_" + dataReader.GetString(3);
                    employeeList.Add(employee);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();


                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LoginUser getUserLoginByEmloyee(Employee employee)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM UserLogin ul WHERE ul.IsActive = '1' AND EmployeeUID = '" + employee.employeeUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                List<Employee> employeeList = new List<Employee>();
                LoginUser user = null;
                while (dataReader.Read())
                {
                    user = new LoginUser(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(3), dataReader.GetBoolean(4));
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();


                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Employee findByEmployeeNIC(string NIC)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM Employee WHERE NIC ='" + NIC + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                Employee employee = null;
                while (dataReader.Read())
                {
                    employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4),dataReader.GetBoolean(5));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void addEmployee(Employee employee, string loginUSerName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "INSERT INTO Employee(EmployeeID,FirstName,LastName,NIC,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate) VALUES " +
                    "('" + employee.employeeID + "','" + employee.firstName + "','" + employee.lastName + "','" + employee.NIC + "','" + loginUSerName + "','" + DateTime.Now + "','" + loginUSerName + "','" + DateTime.Now + "') ";

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

        public int getEmploeeUIDByAll(Employee emp)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM Employee WHERE EmployeeID ='" + emp.employeeID + "' AND FirstName ='" + emp.firstName + "' AND LastName ='" + emp.lastName + "' AND NIC ='" + emp.NIC + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                int employeeUID = 0;
                while (dataReader.Read())
                {
                    employeeUID = dataReader.GetInt32(0);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return employeeUID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void editEmployee(Employee employee, string loginUserName)
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                String sql = "UPDATE Employee SET EmployeeID = '"+employee.employeeID+"',FirstName = '" + employee.firstName + "',LastName = '" + employee.lastName + "',NIC = '" + employee.NIC + "',IsActive = '"+employee.isActive+"',LastModifiedBy = '" + loginUserName + "',LastModifiedDate ='" + DateTime.Now + "' "+
                            "WHERE  EmployeeUID = "+employee.employeeUID;

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

        public Employee findByEmployeeNICAndEmpUID(int employeeUID,string NIC)
        {

            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["conns"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();


                String sql = "SELECT * FROM Employee WHERE NIC ='" + NIC + "' AND EmployeeUID <>'"+ employeeUID + "' ";

                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                Employee employee = null;
                while (dataReader.Read())
                {
                    employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetBoolean(5));
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
