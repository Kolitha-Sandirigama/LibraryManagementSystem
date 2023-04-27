using AuthenticationUt.DAL;
using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Controller
{
    public class FunctionControllerImpl : FunctionController
    {

        public List<Functions> GetUserFunctionCodeList(string userCode) 
        {
            FunctionDAO functionDAO = new FunctionDAOImpl();
            return functionDAO.GetUserFunctionCodeList(userCode);
        }

        public int GetFunctionCodeByPageName(string pageName)
        {
            FunctionDAO functionDAO = new FunctionDAOImpl();
            return functionDAO.GetFunctionCodeByPageName(pageName);
        }

    }
}
