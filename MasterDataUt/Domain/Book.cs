using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class Book
    {
        public Book()
        {
        }

        public int bookUID { get; set; }
        public String bookID { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String ISBNNo { get; set; }
        public bool isActive { get; set; }
        public int bookCategoryUID { get; set; }

        public Book(int bookUID, string bookID, string name, string Author, string ISBNNo, bool isActive, int bookCategoryUID)
        {
            this.bookUID = bookUID;
            this.bookID = bookID;
            this.Name = name;
            this.Author = Author;
            this.ISBNNo = ISBNNo;
            this.isActive = isActive;
            this.bookCategoryUID = bookCategoryUID;
        }

        public Book(string bookID, string name, string Author, string ISBNNo, bool isActive, int bookCategoryUID)
        {
            this.bookID = bookID;
            this.Name = name;
            this.Author = Author;
            this.ISBNNo = ISBNNo;
            this.isActive = isActive;
            this.bookCategoryUID = bookCategoryUID;
        }
    }
}
