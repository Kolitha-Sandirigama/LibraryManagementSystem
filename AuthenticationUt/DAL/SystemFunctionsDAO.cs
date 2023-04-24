using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface SystemFunctionsDAO
    {
        List<SystemFunction> getAllFunctions();                                 // get all function list
        void addFunction(SystemFunction systemFunction, string userName);       // add new function
        void updateFunction(SystemFunction systemFunction, string userName);    // update function details
        bool checkIsExistsByFunctionName(string functionName);                  // check whether function name already added or not
        List<SystemFunction> getAllFunctionListByRole(int roleUID);             // get function list which is not allocated to roleuid
        List<SystemFunction> getSelectedFunctionListByRole(int roleUID);        // get function list which is allocated to roleuid
        List<SystemFunction> getSelectedFunctionList();                         // get all function list
    }
}
