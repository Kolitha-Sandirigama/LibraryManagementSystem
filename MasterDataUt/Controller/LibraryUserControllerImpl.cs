using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class LibraryUserControllerImpl : LibraryUserController
    {
        public List<LibraryUser> findByAll() 
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.findByAll();
        }

        public void addLibraryUser(String userID, String userFirstName, String userLastName, String userNIC, int userCategoryId, string loginUSerName)
        {
            LibraryUser libraryUser = new LibraryUser(userID,userFirstName,userLastName,userNIC,userCategoryId,"");
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            libraryUserDAO.addLibraryUser(libraryUser, loginUSerName);
        }

        public LibraryUser findByLibraryUserNIC(string NIC)
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.findByLibraryUserNIC(NIC);
        }

        public int getLibraryUserUIDByAll(LibraryUser libraryUser)
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.getLibraryUserUIDByAll(libraryUser);
        }

        public void editLibraryUser(int userUID, String userID, String userFirstName, String userLastName, String userNIC, int userCategoryId, bool isActive, string loginUSerName)
        {
            LibraryUser libraryUser = new LibraryUser(userUID,userID,userFirstName,userLastName,userNIC,isActive,userCategoryId,"");
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            libraryUserDAO.editLibraryUser(libraryUser, loginUSerName);
        }

        public LibraryUser findByLibraryUserNICAndLibraryUserUID(int libraryUserUID, string NIC)
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.findByLibraryUserNICAndLibraryUserUID(libraryUserUID, NIC);
        }

        public List<LibraryUser> findByActiveAll()
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.findByActiveAll();
        }

        public List<LibraryUserCategory> getActiveLibraryUserCategoryList() 
        {
            LibraryUserCategoryDAO libraryUserCategoryDAO = new LibraryUserCategoryDAOImpl();
            return libraryUserCategoryDAO.getAllLibraryUserCategories();
        }

        public int getNextSequenceNo()
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.getNextSequenceNo();
        }
    }
}
