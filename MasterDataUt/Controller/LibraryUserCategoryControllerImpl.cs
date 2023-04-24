using MasterDataUt.DAL;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Controller
{
    public class LibraryUserCategoryControllerImpl : LibraryUserCategoryController
    {
        public List<LibraryUserCategory> getAllLibraryUserCategories()
        {
            LibraryUserCategoryDAO libraryUserCategoryDAO = new LibraryUserCategoryDAOImpl();
            return libraryUserCategoryDAO.getAllLibraryUserCategories();
        }

        public void addLibraryUserCategory(string description, string notes, bool isActive, string userName)
        {
            LibraryUserCategoryDAO libraryUserCategoryDAO = new LibraryUserCategoryDAOImpl();
            LibraryUserCategory libraryUserCategory = new LibraryUserCategory(description, notes, isActive);
            libraryUserCategoryDAO.addLibraryUserCategory(libraryUserCategory, userName);
        }

        public void updateLibraryUserCategory(int libraryUserCategoryUID, string description, string notes, bool isActive, string userName)
        {
            LibraryUserCategoryDAO libraryUserCategoryDAO = new LibraryUserCategoryDAOImpl();
            LibraryUserCategory libraryUserCategory = new LibraryUserCategory(libraryUserCategoryUID, description, notes, isActive);
            libraryUserCategoryDAO.updateLibraryUserCategory(libraryUserCategory, userName);
        }

        public bool checkIsExistsByLibraryUserCategoryName(string libraryUserCategoryName)
        {
            LibraryUserCategoryDAO libraryUserCategoryDAO = new LibraryUserCategoryDAOImpl();
            return libraryUserCategoryDAO.checkIsExistsByLibraryUserCategoryName(libraryUserCategoryName);
        }
    }
}
