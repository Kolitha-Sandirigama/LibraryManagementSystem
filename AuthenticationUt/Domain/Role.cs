using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class Role
    {
        public int roleUID { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }

        public Role()
        { 
        }

        public Role(int roleUID, string name, bool isActive)
        {
            this.roleUID = roleUID;
            this.name = name;
            this.isActive = isActive;
        }
    }
}
