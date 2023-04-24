using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface RoleFunctionsController
    {
        List<Role> getActiveRole();
        List<SystemFunction> getAllFunctionListByRole(int roleUID);
        List<SystemFunction> getSelectedFunctionListByRole(int roleUID);
        void saveRoleFuntions(int roleUID,List<SystemFunction> selectedFunctionList, string userName);
        List<RoleSystemFuntion> getRoleFunctionListByRole(int roleUID);
    }
}
