using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.DAL
{
    public interface FunctionDAO
    {
        List<Functions> GetUserFunctionCodeList(string UserCode);
        int GetFunctionCodeByPageName(string pageName);
    }
}
