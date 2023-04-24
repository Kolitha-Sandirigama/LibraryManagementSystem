using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class BookCategoryControllerImpl:BookCategoryController
    {
        public List<BookCategory> getAllBookCategories()
        {
            BookCategoryDAO bookCategoryDAO = new BookCategoryDAOImpl();
            return bookCategoryDAO.getAllBookCategories();
        }

        public void addBookCategory(string description, string notes, bool isActive, string userName)
        {
            BookCategoryDAO bookCategoryDAO = new BookCategoryDAOImpl();
            BookCategory bookCategory = new BookCategory(description, notes, isActive);
            bookCategoryDAO.addBookCategory(bookCategory, userName);
        }

        public void updateBookCategory(int bookCategoryUID, string description, string notes, bool isActive, string userName)
        {
            BookCategoryDAO bookCategoryDAO = new BookCategoryDAOImpl();
            BookCategory bookCategory = new BookCategory(bookCategoryUID, description, notes, isActive);
            bookCategoryDAO.updateBookCategory(bookCategory, userName);
        }

        public bool checkIsExistsByBookCategoryName(string bookCategoryName)
        {
            BookCategoryDAO bookCategoryDAO = new BookCategoryDAOImpl();
            return bookCategoryDAO.checkIsExistsByBookCategoryName(bookCategoryName);
        }
    }
}
