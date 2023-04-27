using MasterDataUt.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class DashBoardControllerImpl : DashBoardController
    {
        public int getTotalActiveBookCount() 
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.getTotalActiveBookCount();
        }

        public int getTotalAvailableBookCount()
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.getTotalAvailableBookCount();
        }

        public int getTotalBorrowedBookCount()
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.getTotalBorrowedBookCount();
        }

        public int getTotalActiveUserCount()
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.getTotalActiveUserCount();
        }
    }
}
