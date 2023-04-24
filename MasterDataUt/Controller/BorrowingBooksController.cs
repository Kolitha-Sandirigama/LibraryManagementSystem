using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface BorrowingBooksController
    {
        List<BookBorrowingRecord> findByAll();
        List<Book> getActiveBookList();
        List<LibraryUser> getActiveUserList();
        void addBorrowingBookRecord(int bookUID, int UserUID, DateTime returnDate, String UserID);
    }
}
