using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface EmployeeDAO
    {
        List<Employee> findByAll();                                        // Active user employee details
        void addEmployee(Employee employee, string loginUSerName);         // Add new Employee details
        Employee findByEmployeeNIC(string NIC);                            // get employee details by NIC 
        int getEmploeeUIDByAll(Employee emp);                              // get Employee by EmployeeID, Name and NIC 
        void editEmployee(Employee employee, string loginUSerName);        // Update Employee
        Employee findByEmployeeNICAndEmpUID(int employeeUID,string NIC);   // get Employee by employeeUID and  NIC
        List<Employee> findByActiveAll();                                  // find all active employees
    }
}
