using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public interface BookCategoryDAO
    {
        List<BookCategory> getAllBookCategories();                                 
        void addBookCategory(BookCategory bookCategory, string userName);       
        void updateBookCategory(BookCategory bookCategory, string userName);    
        bool checkIsExistsByBookCategoryName(string bookCategoryName);
        List<BookCategory> getActiveBookCategoryList();
    }
}
