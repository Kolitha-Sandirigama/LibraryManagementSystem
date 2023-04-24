using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class LibraryUserCategory
    {
        public int libraryUserCategoryUID { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public bool isActive { get; set; }

        public LibraryUserCategory()
        { }

        public LibraryUserCategory(int libraryUserCategoryUID, string description, string notes, bool isActive)
        {
            this.libraryUserCategoryUID = libraryUserCategoryUID;
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }

        public LibraryUserCategory(string description, string notes, bool isActive)
        {
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }
    }
}
