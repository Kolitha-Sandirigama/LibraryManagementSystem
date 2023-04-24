using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class BorrowingBooksControllerImpl : BorrowingBooksController
    {
        public List<BookBorrowingRecord> findByAll()
        {
            BorrowingBooksDAO borrowingBooksDAO = new BorrowingBooksDAOImpl();
            return borrowingBooksDAO.findByAll();
        }

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

        public void addBorrowingBookRecord(int bookUID, int UserUID, DateTime returnDate, String UserID) 
        {
            BorrowingBooksDAO borrowingBooksDAO = new BorrowingBooksDAOImpl();
            BookBorrowingRecord bookBorrowingRecord = new BookBorrowingRecord(bookUID, UserUID, returnDate);
            borrowingBooksDAO.addBorrowingBookRecord(bookBorrowingRecord, UserID);
        }

    }
}
