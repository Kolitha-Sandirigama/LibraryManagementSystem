using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.DAL
{
    public interface LibraryUserCategoryDAO
    {
        List<LibraryUserCategory> getAllLibraryUserCategories();
        void addLibraryUserCategory(LibraryUserCategory libraryUserCategory, string userName);
        void updateLibraryUserCategory(LibraryUserCategory libraryUserCategory, string userName);
        bool checkIsExistsByLibraryUserCategoryName(string libraryUserCategoryName);
    }
}
