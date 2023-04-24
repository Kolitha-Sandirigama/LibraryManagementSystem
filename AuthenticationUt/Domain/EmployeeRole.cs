using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class EmployeeRole
    {
        public int employeeUID { get; set; }                // employee UID
        public string employeeID { get; set; }
        public string firstName { get; set; }               // employee first name
        public string lastName { get; set; }                // employee last name
        public int roleUID { get; set; }                    // Role UID
        public string roleName { get; set; }                // role Name
        public bool isActive { get; set; }

        public EmployeeRole() { }
        public EmployeeRole(int employeeUID, string employeeID, string firstName, string lastName, int roleUID, string roleName, bool isActive) 
        {
            this.employeeUID = employeeUID;
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.roleUID = roleUID;
            this.roleName = roleName;
            this.isActive = isActive;
        }

    }
}
