using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class BookCategory
    {
        public int bookCategoryUID { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public bool isActive { get; set; }

        public BookCategory()
        { }

        public BookCategory(int bookCategoryUID, string description, string notes, bool isActive)
        {
            this.bookCategoryUID = bookCategoryUID;
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }

        public BookCategory(string description, string notes, bool isActive)
        {
            this.description = description;
            this.notes = notes;
            this.isActive = isActive;
        }
    }
}
