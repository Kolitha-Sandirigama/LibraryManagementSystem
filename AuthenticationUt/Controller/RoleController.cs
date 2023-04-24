using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;


namespace AuthenticationUt.Controller
{
    public interface RoleController
    {
        void addRole(string roleName, bool isActive, string loginUserName);
        void updateRole(int roleUID, string roleName, bool isActive, string loginUserName);
        List<Role> getAllRole();
        bool getIsExistByName(string roleName);
        bool getIsExistByNameAndRoleUID(string Name, int roleUID);
    }
}
