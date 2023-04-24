using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface SystemFunctionsController
    {
        List<SystemFunction> getAllFunctions();
        void addFunction(string description, string notes, bool isActive, string userName);
        void updateFunction(int functionUID, string description, string notes, bool isActive, string userName);
        bool checkIsExistsByFunctionName(string functionName);
    }
}
