using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface BookController
    {
        List<Book> findByAll();
        void addBook(String bookID, String name, String Author, String ISBNNo, int bookCategoryUID, string loginUSerName);
        Book findByBookISBN(string isbnNo);
        int getBookUIDByAll(Book book);
        void editBook(int bookUID, String bookID, String name, String Author, String ISBNNo, int bookCategoryUID, bool isActive, string loginUSerName);
        Book findByBookISBNAndBookUID(int BookUID, string ISBN);
        List<Book> findByActiveAll();
        List<BookCategory> getActiveBookCategoryList();
        int getNextSequenceNo();
    }
}
