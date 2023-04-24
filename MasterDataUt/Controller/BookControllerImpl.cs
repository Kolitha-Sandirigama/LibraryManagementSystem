using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class BookControllerImpl: BookController
    {
        public List<Book> findByAll() 
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.findByAll();
        }

        public void addBook(String bookID, String name, String Author, String ISBNNo, int bookCategoryUID, string loginUSerName)
        {
            BookDAO bookDAO = new BookDAOImpl();
            Book book = new Book(bookID,name,Author,ISBNNo,true,bookCategoryUID); 
            bookDAO.addBook(book,loginUSerName);
        }

        public Book findByBookISBN(string isbnNo)
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.findByBookISBN(isbnNo);
        }

        public int getBookUIDByAll(Book book)
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.getBookUIDByAll(book);
        }

        public void editBook(int bookUID, String bookID, String name, String Author, String ISBNNo, int bookCategoryUID, bool isActive, string loginUSerName)
        {
            BookDAO bookDAO = new BookDAOImpl();
            Book book = new Book(bookUID,bookID, name, Author, ISBNNo, isActive, bookCategoryUID);
            bookDAO.editBook(book, loginUSerName);
        }

        public Book findByBookISBNAndBookUID(int bookUID, string ISBN)
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.findByBookISBNAndBookUID(bookUID,ISBN);
        }

        public List<Book> findByActiveAll()
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.findByActiveAll();
        }

        public List<BookCategory> getActiveBookCategoryList()
        {
            BookCategoryDAO bookCategoryDAO = new BookCategoryDAOImpl();
            return bookCategoryDAO.getActiveBookCategoryList();
        }

        public int getNextSequenceNo()
        {
            BookDAO bookDAO = new BookDAOImpl();
            return bookDAO.getNextSequenceNo();
        }

    }
}
