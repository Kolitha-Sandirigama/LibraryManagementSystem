using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public interface EmployeeController
    {
        List<Employee> findByAll();
        Employee findByEmployeeNIC(string NIC);
        void addEmployee(string EmployeeID, string FirstName, string LastName, string NIC, string loginUSerName);
        int getEmploeeUIDByAll(string EmployeeID, string FirstName, string LastName, string NIC);
        void editEmployee(int EmployeeUID, string EmployeeID, string FirstName, string LastName, string NIC, string loginUSerName, bool isactive);
        Employee findByEmployeeNICAndEmpUID(int EmployeeUID,string NIC);
        LoginUser findByUserLoginID(string userLogingID);
        void addUserLogin(string userName, bool isActive, int EmployeeUID, string loginUSerName);
    }
}
