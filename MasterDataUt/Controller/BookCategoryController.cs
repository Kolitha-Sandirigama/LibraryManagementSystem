using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDataUt.Domain;

namespace MasterDataUt.Controller
{
    public interface BookCategoryController
    {
        List<BookCategory> getAllBookCategories();
        void addBookCategory(string description, string notes, bool isActive, string userName);
        void updateBookCategory(int bookCategoryUID, string description, string notes, bool isActive, string userName);
        bool checkIsExistsByBookCategoryName(string bookCategoryName);
    }
}
