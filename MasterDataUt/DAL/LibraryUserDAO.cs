using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface LibraryUserDAO
    {
        List<LibraryUser> findByAll();                                        
        void addLibraryUser(LibraryUser libraryUser, string loginUSerName);
        LibraryUser findByLibraryUserNIC(string NIC);                             
        int getLibraryUserUIDByAll(LibraryUser libraryUser);                               
        void editLibraryUser(LibraryUser libraryUser, string loginUSerName);
        LibraryUser findByLibraryUserNICAndLibraryUserUID(int libraryUserUID, string NIC);   
        List<LibraryUser> findByActiveAll();
        int getNextSequenceNo();
    }
}
