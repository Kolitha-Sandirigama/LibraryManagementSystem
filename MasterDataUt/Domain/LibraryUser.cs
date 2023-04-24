using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class LibraryUser
    {
        public LibraryUser()
        {
        }

        public int userUID { get; set; }                    
        public String userID { get; set; }                  
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String NIC { get; set; }
        public String userFullName { get; set; }              
        public bool isActive { get; set; }
        public int LibraryUserCategoryUID { get; set; }
        public String LibraryUserCategoryName { get; set; }

        public LibraryUser(int userUID, string userID, string firstName, string lastName, string NIC, bool isActive, int LibraryUserCategoryUID, String LibraryUserCategoryName)
        {
            this.userUID = userUID;
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.NIC = NIC;
            this.isActive = isActive;
            this.LibraryUserCategoryUID = LibraryUserCategoryUID;
            this.LibraryUserCategoryName = LibraryUserCategoryName;
        }

        public LibraryUser(string userID, string firstName, string lastName, string NIC, int LibraryUserCategoryUID, String LibraryUserCategoryName)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.NIC = NIC;
            this.LibraryUserCategoryUID = LibraryUserCategoryUID;
            this.LibraryUserCategoryName = LibraryUserCategoryName;
        }

    }
}
