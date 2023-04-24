using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;
using AuthenticationUt.DAL;

namespace AuthenticationUt.Controller
{
    public class SystemPagesControllerImpl: SystemPagesController
    {
        public void addSystemPage(string pageName, string URL, string description, string userName)
        {
            SystemPagesDAO systemPagesDAO = new SystemPagesDAOImpl();
            SystemPage systemPage = new SystemPage(pageName, URL, description);
            systemPagesDAO.addSystemPage(systemPage, userName);
        }

        public List<SystemPage> getSystemPagesByAll()
        {
            SystemPagesDAO systemPagesDAO = new SystemPagesDAOImpl();
            return systemPagesDAO.getSystemPagesByAll();
        }
    }
}
