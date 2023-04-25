using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public interface BorrowingBooksDAO
    {
        List<BookBorrowingRecord> findByAll();
        void addBorrowingBookRecord(BookBorrowingRecord bookBorrowingRecord, String UserID);
        void updateBorrowingBookRecord(BookBorrowingRecord bookBorrowingRecord, String UserID);
        bool checkIsBookAvailableByBookUID(int bookUID);
    }
}
