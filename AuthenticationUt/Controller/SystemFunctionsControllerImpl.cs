using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class SystemFunctionsControllerImpl: SystemFunctionsController
    {
        public List<SystemFunction> getAllFunctions() 
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            return systemFunctionsDAO.getAllFunctions();
        }

        public void addFunction(string description, string notes, bool isActive, string userName)
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            SystemFunction systemFunction = new SystemFunction(description, notes, isActive);
            systemFunctionsDAO.addFunction(systemFunction, userName);
        }

        public void updateFunction(int functionUID,string description, string notes, bool isActive, string userName)
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            SystemFunction systemFunction = new SystemFunction(functionUID,description, notes, isActive);
            systemFunctionsDAO.updateFunction(systemFunction, userName);
        }

        public bool checkIsExistsByFunctionName(string functionName)
        {
            SystemFunctionsDAO systemFunctionsDAO = new SystemFunctionsDAOImpl();
            return systemFunctionsDAO.checkIsExistsByFunctionName(functionName);
        }
    }
}
