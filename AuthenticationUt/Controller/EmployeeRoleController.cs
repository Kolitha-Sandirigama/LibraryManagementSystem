using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface EmployeeRoleController
    {
        List<Role> getActiveRoleList();
        List<Employee> getActiveEmployeeList();
        List<EmployeeRole> getAllEmployeeRoles();
        void addEmployeeRole(int employeeUID, int roleUID, bool isActive, String userID);
        void updateEmployeeRole(int employeeUID, int roleUID, bool isActive, String userID);
        bool isEmployeeRoleExists(int employeeUID, int roleUID);
    }
}
