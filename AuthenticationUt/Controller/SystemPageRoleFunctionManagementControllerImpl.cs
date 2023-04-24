using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class SystemPageRoleFunctionManagementControllerImpl : SystemPageRoleFunctionManagementController
    {
        public List<Role> getActiveRoleList()
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getAllActiveRole();
        }

        public List<SystemFunction> getsystemFunctions()
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            return systemFunctionsDAO.getSelectedFunctionList();

        }

        public List<SystemPage> getAllPageListByFuncionUID( int functionUID)
        {
            SystemPagesDAO systemPagesDAO = new SystemPagesDAOImpl();
            return systemPagesDAO.getAllPageListByFuncionUID(functionUID);
        }

        public List<SystemPage> getSelectedPageListByFuncionUID(int functionUID)
        {
            SystemPagesDAO systemPagesDAO = new SystemPagesDAOImpl();
            return systemPagesDAO.getSelectedPageListByFuncionUID(functionUID);
        }

        public List<SystemPageFunction> getSystemPageFunctionListByFunctionUID(int functionUID)
        {
            SystemPageFunctionDAO systemPageFunctionDAO = new SystemPageFunctionDAOImpl();
            return systemPageFunctionDAO.getSystemPageFunctionListByFunctionUID(functionUID);
        }

        public void addSystemPageFunction(int functionUID, List<SystemPage> selectedPageList,string userName)
        {
            SystemPageFunctionDAO systemPageFunctionDAO = new SystemPageFunctionDAOImpl();
            systemPageFunctionDAO.deleteSystemPageByFunctionUID(functionUID);

            foreach (SystemPage systemPage in selectedPageList)
            {
                systemPageFunctionDAO.addSystemPageFunction(functionUID,systemPage, userName);
            }
        }


    }
}
