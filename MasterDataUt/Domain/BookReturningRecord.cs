using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class BookReturningRecord
    {
        public int bookReturningRecordUID { get; set; }
        public int bookUID { get; set; }
        public String bookID { get; set; }
        public String bookName { get; set; }
        public int userUID { get; set; }
        public String userID { get; set; }
        public String userName { get; set; }
        public bool isActive { get; set; }
        public String ISBNNo { get; set; }

        public BookReturningRecord() { }

        public BookReturningRecord(int bookReturningRecordUID, int bookUID, String bookName, int userUID, String userName, bool isActive, String ISBNNo)
        {
            this.bookReturningRecordUID = bookReturningRecordUID;
            this.bookUID = bookUID;
            this.bookName = bookName;
            this.userUID = userUID;
            this.userName = userName;
            this.isActive = isActive;
            this.ISBNNo = ISBNNo;
        }

        public BookReturningRecord(int bookUID, int userUID)
        {
            this.bookUID = bookUID;
            this.userUID = userUID;
        }
    }
}
