using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    [Serializable]
    public class LoginUser
    {
        public int UserLoginID { get; set; }                                    // Login UID
        public string UserName { get; set; }                                    // User Name
        public string UserPassword { get; set; }                                // Password
        public int EmployeeUID { get; set; }                                     // Employee UID
        public bool IsActive { get; set; }                                      // active user
        public string EnteredUserId { get; set; }
        public string EnterDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public string LastModifiedDate { get; set; }

        public LoginUser() {}

        public LoginUser(int UserLoginID, string UserName, int EmployeeUID, bool IsActive)
        {
            this.UserLoginID = UserLoginID;
            this.UserName = UserName;
            this.EmployeeUID = EmployeeUID;
            this.IsActive = IsActive;
        }

        public LoginUser(string UserName, int EmployeeUID, bool IsActive)
        {
            this.UserName = UserName;
            this.EmployeeUID = EmployeeUID;
            this.IsActive = IsActive;
        }
    }
}
