using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.DAL;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public class EmployeeControllerImpl : EmployeeController
    {
        public List<Employee> findByAll()
        {
            try
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();

                return employeeDAO.findByAll();

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Employee findByEmployeeNIC(string NIC)
        {
            try
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();

                return employeeDAO.findByEmployeeNIC(NIC);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void addEmployee(string EmployeeID, string FirstName, string LastName, string NIC, string loginUSerName)
        {
            try 
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();
                Employee emp = new Employee(EmployeeID, FirstName, LastName, NIC);
                employeeDAO.addEmployee(emp, loginUSerName);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int getEmploeeUIDByAll(string EmployeeID, string FirstName, string LastName, string NIC)
        {
            try
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();
                Employee emp = new Employee(EmployeeID, FirstName, LastName, NIC);
                return employeeDAO.getEmploeeUIDByAll(emp);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void editEmployee(int EmployeeUID,string EmployeeID, string FirstName, string LastName, string NIC, string loginUSerName,bool isactive)
        {
            try
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();
                Employee emp = new Employee(EmployeeUID,EmployeeID, FirstName, LastName, NIC, isactive);
                employeeDAO.editEmployee(emp,loginUSerName);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Employee findByEmployeeNICAndEmpUID(int employeeUID,string NIC)
        {
            try
            {
                EmployeeDAO employeeDAO = new EmployeeDAOImpl();

                return employeeDAO.findByEmployeeNICAndEmpUID(employeeUID,NIC);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public LoginUser findByUserLoginID(string userName)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();

                return userLoginDAO.findByUserLoginID(userName);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void addUserLogin(string userName, bool isActive, int EmployeeUID, string loginUSerName)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();
                LoginUser user = new LoginUser(userName, EmployeeUID, isActive);
                userLoginDAO.addUserLogin(user, loginUSerName);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

    }
}
