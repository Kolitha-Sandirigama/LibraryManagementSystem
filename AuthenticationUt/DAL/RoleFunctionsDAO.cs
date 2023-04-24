using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface RoleFunctionsDAO
    {
        void saveRoleFuntions(int roleUID, SystemFunction selectedFunction, string userName);  // add new role function
        void deleteRoleFuntions(int roleUID);                                                  // delete systemFuntions allocated to a role(by roleUID)
        List<RoleSystemFuntion> getRoleFunctionListByRole(int roleUID);                        // get all functions allocated to a role by roleUID
    }
}
