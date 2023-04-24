using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.DAL
{
    public interface SystemPagesDAO
    {
        void addSystemPage(SystemPage systemPage, string userName);             // add new system page
        List<SystemPage> getSystemPagesByAll();                                 // get all pages list
        List<SystemPage> getAllPageListByFuncionUID(int functionUID);           // get pages list which is not allocated to a function
        List<SystemPage> getSelectedPageListByFuncionUID(int functionUID);      // get pages list which is allocated to a function
    }
}
