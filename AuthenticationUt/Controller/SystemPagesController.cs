using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface SystemPagesController
    {
        void addSystemPage(string pageName, string URL, string description, string userName);
        List<SystemPage> getSystemPagesByAll();
    }
}
