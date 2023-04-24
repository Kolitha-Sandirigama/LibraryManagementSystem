using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class SystemPage
    {
        public int systemPageUID { get; set; }
        public string systemPageName { get; set; }
        public string systemPageURL { get; set; }
        public string description { get; set; }

        public SystemPage()
        { 
        }

        public SystemPage(int systemPageUID, string systemPageName, string systemPageURL, string description)
        {
            this.systemPageUID = systemPageUID;
            this.systemPageName = systemPageName;
            this.systemPageURL = systemPageURL;
            this.description = description;
        }

        public SystemPage(string systemPageName, string systemPageURL, string description)
        {
            this.systemPageName = systemPageName;
            this.systemPageURL = systemPageURL;
            this.description = description;
        }
    }
}
