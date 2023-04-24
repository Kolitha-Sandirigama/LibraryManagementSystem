using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public interface LibraryUserCategoryController
    {
        List<LibraryUserCategory> getAllLibraryUserCategories();
        void addLibraryUserCategory(string description, string notes, bool isActive, string userName);
        void updateLibraryUserCategory(int libraryUserCategoryUID, string description, string notes, bool isActive, string userName);
        bool checkIsExistsByLibraryUserCategoryName(string libraryUserCategoryName);
    }
}
