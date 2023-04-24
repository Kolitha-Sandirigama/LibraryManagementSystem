using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class Employee
    {
        public Employee()
        {
        }

        public int employeeUID { get; set; }                    // Employee UID
        public String employeeID { get; set; }                  // Employee ID
        public String firstName { get; set; }                   
        public String lastName { get; set; }
        public String NIC { get; set; }
        public String employeeIDName { get; set; }              // full name (first name + last Name)
        public bool isActive { get; set; }
        public LoginUser userLogin { get; set; }

        public Employee(int employeeUID, string employeeID, string firstName, string lastName, string NIC,bool isActive)
        {
            this.employeeUID = employeeUID;
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.NIC = NIC;
            this.isActive = isActive;
        }

        public Employee(string employeeID, string firstName, string lastName, string NIC)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.NIC = NIC;
        }

        public void addUserLogin(LoginUser user) {
            this.userLogin = user;
        }

    }
}
