using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Controller
{
    public interface FunctionController
    {
        List<Functions> GetUserFunctionCodeList(string userCode);
        int GetFunctionCodeByPageName(string pageName);
    }
}
