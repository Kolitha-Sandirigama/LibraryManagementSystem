using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface LibraryUserController
    {
        List<LibraryUser> findByAll();
        void addLibraryUser(String userID, String userFirstName, String userLastName, String userNIC, int userCategoryId, string loginUSerName);
        LibraryUser findByLibraryUserNIC(string NIC);
        int getLibraryUserUIDByAll(LibraryUser libraryUser);
        void editLibraryUser(int userUID, String userID, String userFirstName, String userLastName, String userNIC, int userCategoryId,bool isActive, string loginUSerName);
        LibraryUser findByLibraryUserNICAndLibraryUserUID(int libraryUserUID, string NIC);
        List<LibraryUser> findByActiveAll();
        List<LibraryUserCategory> getActiveLibraryUserCategoryList();
        int getNextSequenceNo();
    }
}
