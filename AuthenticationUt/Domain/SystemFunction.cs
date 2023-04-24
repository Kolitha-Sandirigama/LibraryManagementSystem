using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class SystemFunction
    {
        public int systemFunctionUID { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public bool isActive { get; set; }

        public SystemFunction() 
        { }

        public SystemFunction(int systemFunctionUID, string description, string notes, bool isActive)
        {
            this.systemFunctionUID = systemFunctionUID;
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }

        public SystemFunction(string description, string notes, bool isActive)
        {
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }
    }
}
