using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public interface ReturningBooksDAO
    {
        List<BookReturningRecord> findByAll();
        void addReturningBookRecord(BookReturningRecord bookReturningRecord, String UserID);
        void updateReturningBookRecord(BookReturningRecord bookReturningRecord, String UserID);
    }
}
