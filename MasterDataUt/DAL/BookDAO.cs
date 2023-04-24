using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public interface BookDAO
    {
        List<Book> findByAll();
        void addBook(Book book, string loginUSerName);
        Book findByBookISBN(string isbnNo);
        int getBookUIDByAll(Book book);
        void editBook(Book book, string loginUSerName);
        Book findByBookISBNAndBookUID(int BookUID, string ISBN);
        List<Book> findByActiveAll();
        int getNextSequenceNo();

    }
}
