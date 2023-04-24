using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class RoleControllerImpl: RoleController
    {

        public void addRole(string roleName, bool isActive, string loginUserName)
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            roleDAO.addRole(roleName, isActive, loginUserName);
        }
        public void updateRole(int roleUID, string roleName, bool isActive, string loginUserName)
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            roleDAO.updateRole(roleUID, roleName, isActive, loginUserName);
        }
        public List<Role> getAllRole()
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getAllRole();
        }

        public bool getIsExistByName(string roleName)
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getIsExistByName(roleName);
        }

        public bool getIsExistByNameAndRoleUID(string roleName, int roleUID)
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getIsExistByNameAndUID(roleName, roleUID);
        }

    }
}
