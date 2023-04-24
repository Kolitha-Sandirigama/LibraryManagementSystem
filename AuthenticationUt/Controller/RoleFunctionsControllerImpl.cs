using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class RoleFunctionsControllerImpl: RoleFunctionsController
    {
        public List<Role> getActiveRole()
        {
            RoleDAO roleDAO = new RoleDAOImpl();
            return roleDAO.getAllActiveRole();
        }

        public List<SystemFunction> getAllFunctionListByRole(int roleUID)
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            return systemFunctionsDAO.getAllFunctionListByRole(roleUID);
        }

        public List<SystemFunction> getSelectedFunctionListByRole(int roleUID)
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            return systemFunctionsDAO.getSelectedFunctionListByRole(roleUID);
        }

        public void saveRoleFuntions(int roleUID, List<SystemFunction> selectedFunctionList, string userName)
        {
            RoleFunctionsDAO roleFunctionsDAO = new RoleFunctionsDAOImpl();
            this.deleteRoleFuntions(roleUID);
            foreach (SystemFunction systemFunction in selectedFunctionList)
            {
                roleFunctionsDAO.saveRoleFuntions(roleUID, systemFunction, userName);
            }
        }

        public void deleteRoleFuntions(int roleUID)
        {
            RoleFunctionsDAO roleFunctionsDAO = new RoleFunctionsDAOImpl();
            roleFunctionsDAO.deleteRoleFuntions(roleUID);
        }

        public List<RoleSystemFuntion> getRoleFunctionListByRole(int roleUID)
        {
            RoleFunctionsDAO roleFunctionsDAO = new RoleFunctionsDAOImpl();
            return roleFunctionsDAO.getRoleFunctionListByRole(roleUID);
        }
    }
}
