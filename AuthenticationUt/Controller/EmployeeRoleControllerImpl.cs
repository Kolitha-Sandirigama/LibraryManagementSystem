using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class EmployeeRoleControllerImpl : EmployeeRoleController
    {
        public List<Role> getActiveRoleList()
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getAllActiveRole();
        }

        public List<Employee> getActiveEmployeeList()
        {
            EmployeeDAO employeeDAO = new EmployeeDAOImpl();
            return employeeDAO.findByActiveAll();
        }

        public List<EmployeeRole> getAllEmployeeRoles()
        {
            EmployeeRoleDAO employeeRoleDAO = new EmployeeRoleDAOImpl();
            return employeeRoleDAO.getAllEmployeeRoles();
        }

        public void addEmployeeRole(int employeeUID, int roleUID, bool isActive,String userID)
        {
            EmployeeRoleDAO employeeRoleDAO = new EmployeeRoleDAOImpl();
            EmployeeRole empRole = new EmployeeRole();
            empRole.employeeUID = employeeUID;
            empRole.roleUID = roleUID;
            empRole.isActive = isActive;
            employeeRoleDAO.addEmployeeRole(empRole, userID);
        }

        public void updateEmployeeRole(int employeeUID, int roleUID, bool isActive, String userID)
        {
            EmployeeRoleDAO employeeRoleDAO = new EmployeeRoleDAOImpl();
            EmployeeRole empRole = new EmployeeRole();
            empRole.employeeUID = employeeUID;
            empRole.roleUID = roleUID;
            empRole.isActive = isActive;
            employeeRoleDAO.updateEmployeeRole(empRole, userID);
        }

        public bool isEmployeeRoleExists(int employeeUID, int roleUID)
        {
            EmployeeRoleDAO employeeRoleDAO = new EmployeeRoleDAOImpl();
            EmployeeRole empRole = new EmployeeRole();
            empRole.employeeUID = employeeUID;
            empRole.roleUID = roleUID;
            return employeeRoleDAO.isEmployeeRoleExists(empRole);
        }
    }
}
