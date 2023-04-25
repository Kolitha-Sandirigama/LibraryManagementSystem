using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class ReturningBooksControllerImpl : ReturningBooksController
    {
        public List<Book> getActiveBookList()
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.findByActiveAll();

        }

        public List<LibraryUser> getActiveUserList()
        {
            LibraryUserDAO libraryUserDAO = new LibraryUserDAOImpl();
            return libraryUserDAO.findByActiveAll();
        }

        public List<BookReturningRecord> findByAll()
        {
            ReturningBooksDAO returningBooksDAO = new ReturningBooksDAOImpl();
            return returningBooksDAO.findByAll();
        }

        public void addReturningBookRecord(int bookUID, int UserUID, String UserID)
        {
            ReturningBooksDAO returningBooksDAO = new ReturningBooksDAOImpl();
            BookReturningRecord bookReturningRecord = new BookReturningRecord(bookUID, UserUID);
            returningBooksDAO.addReturningBookRecord(bookReturningRecord, UserID);
        }

        public void updateReturningBookRecord(int bookUID, int UserUID, String UserID)
        {
            ReturningBooksDAO returningBooksDAO = new ReturningBooksDAOImpl();
            BookReturningRecord bookReturningRecord = new BookReturningRecord(bookUID, UserUID);
            returningBooksDAO.updateReturningBookRecord(bookReturningRecord, UserID);
        }

    }
}
