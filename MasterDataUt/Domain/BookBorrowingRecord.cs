using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataUt.Domain
{
    [Serializable]
    public class BookBorrowingRecord
    {
        public int bookBorrowingRecordUID { get; set; }
        public int bookUID { get; set; }
        public String bookID { get; set; }
        public String bookName { get; set; }
        public int userUID { get; set; }
        public String userID { get; set; }
        public String userName { get; set; }
        public DateTime returnDate { get; set; }
        public bool isActive { get; set; }
        public String ISBNNo { get; set; }

        public BookBorrowingRecord() { }

        public BookBorrowingRecord(int bookBorrowingRecordUID, int bookUID, String bookName, int userUID, String userName, DateTime returnDate, bool isActive, String ISBNNo) 
        {
            this.bookBorrowingRecordUID = bookBorrowingRecordUID;
            this.bookUID = bookUID;
            this.bookName = bookName;
            this.userUID = userUID;
            this.userName = userName;
            this.returnDate = returnDate;
            this.isActive = isActive;
            this.ISBNNo = ISBNNo;
        }

        public BookBorrowingRecord(int bookUID, int userUID, DateTime returnDate)
        {
            this.bookUID = bookUID;
            this.userUID = userUID;
            this.returnDate = returnDate;
        }

    }
}
