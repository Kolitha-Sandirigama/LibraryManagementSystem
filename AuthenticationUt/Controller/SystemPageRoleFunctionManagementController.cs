using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface SystemPageRoleFunctionManagementController
    {
        List<Role> getActiveRoleList();
        List<SystemFunction> getsystemFunctions();
        List<SystemPage> getAllPageListByFuncionUID(int functionUID);
        List<SystemPage> getSelectedPageListByFuncionUID(int functionUID);
        List<SystemPageFunction> getSystemPageFunctionListByFunctionUID(int functionUID);
        void addSystemPageFunction(int functionUID, List<SystemPage> selectedPageList,string userName);
    }
}
