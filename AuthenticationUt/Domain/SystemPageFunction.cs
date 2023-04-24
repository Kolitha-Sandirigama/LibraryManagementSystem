using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class SystemPageFunction
    {
        public int systemPageUID { get; set; }
        public string systemPageName { get; set; }
        public int systemFunctionUID { get; set; }
        public string systemFunctionName { get; set; }

        public SystemPageFunction()
        { }

        public SystemPageFunction(int systemPageUID, string systemPageName,  int systemFunctionUID, string systemFunctionName)
        {
            this.systemPageUID = systemPageUID;
            this.systemPageName = systemPageName;
            this.systemFunctionUID = systemFunctionUID;
            this.systemFunctionName = systemFunctionName;
        }
    }
}
