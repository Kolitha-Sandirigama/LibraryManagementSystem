using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface SystemPageFunctionDAO
    {
        List<SystemPageFunction> getSystemPageFunctionListByFunctionUID(int functionUID);       // get all pages list by function UID
        void addSystemPageFunction(int functionUID, SystemPage systemPage, string userName);    // add new pages to a function
        void deleteSystemPageByFunctionUID(int functionUID);                                    // remove a page allocated to a function        
    }
}
