using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class RoleSystemFuntion
    {
        public int roleUID { get; set; }
        public string roleName { get; set; }
        public int functionUID { get; set; }
        public string functionName { get; set; }

        public RoleSystemFuntion()
        { }

        public RoleSystemFuntion(int roleUID, string roleName, int functionUID, string functionName)
        {
            this.roleUID = roleUID;
            this.roleName = roleName;
            this.functionUID = functionUID;
            this.functionName = functionName;
        }
    }
}
