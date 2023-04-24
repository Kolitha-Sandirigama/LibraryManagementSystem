using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface EmployeeRoleDAO
    {
        List<EmployeeRole> getAllEmployeeRoles();                               // get existing all employee role details
        void addEmployeeRole(EmployeeRole employeeRole, string userID);         // add new EmployeeRole
        void updateEmployeeRole(EmployeeRole employeeRole, string userID);      // update employee role details
        bool isEmployeeRoleExists(EmployeeRole employeeRole);                   // check a record already added by employeeUID and RoleUID
    }
}
