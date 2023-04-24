using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface RoleDAO
    {
        void addRole(string roleName, bool isActive, string loginUserName);                     // add new role
        void updateRole(int roleUID, string roleName, bool isActive, string loginUserName);     // update role details
        List<Role> getAllRole();                                                                // get all role details            
        bool getIsExistByName(string roleName);                                                 // Check if the role name already exists by role name
        bool getIsExistByNameAndUID(string roleName, int UID);                                  // Check if the role name already exists by role name and roleUID (excluding this roleUID)
        List<Role> getAllActiveRole();                                                          // get all active roles                        
    }
}
