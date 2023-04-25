using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface ReturningBooksController
    {
        List<Book> getActiveBookList();
        List<LibraryUser> getActiveUserList();
        List<BookReturningRecord> findByAll();
        void addReturningBookRecord(int bookUID, int UserUID, String UserID);
        void updateReturningBookRecord(int bookUID, int UserUID, String UserID);
    }
}
