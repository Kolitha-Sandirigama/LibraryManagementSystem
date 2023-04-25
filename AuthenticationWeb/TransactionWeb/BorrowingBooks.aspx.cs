using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterDataUt.Controller;
using MasterDataUt.Domain;

namespace AuthenticationWeb.TransactionWeb
{
    public partial class BorrowingBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {
                this.dataBindToBookListGrid();          // dat bind to grid
                this.dataBindToddBookList();
                this.dataBindToddUserList();
            }
        }

        protected void dataBindToBookListGrid()
        {
            BorrowingBooksController borrowingBooksController = new BorrowingBooksControllerImpl();
            ViewState["Book_List"] = borrowingBooksController.findByAll();
            gvBorrowingBooks.DataSource = ViewState["Book_List"];
            gvBorrowingBooks.DataBind();

            if (gvBorrowingBooks.Rows.Count > 0)
            {
                hdnBorrowingBookGridVisible.Value = "1";
            }
            else
            {
                hdnBorrowingBookGridVisible.Value = "0";

            }
        }

        private void dataBindToddBookList()
        {
            BorrowingBooksController borrowingBooksController = new BorrowingBooksControllerImpl();
            List<LibraryUser> libraryUserList = new List<LibraryUser>();
            LibraryUser libraryUser = new LibraryUser();
            libraryUser.userUID = -1;
            libraryUser.userFullName = "--Select--";
            libraryUserList.Add(libraryUser);
            libraryUserList.AddRange(borrowingBooksController.getActiveUserList());
            ddUserID.DataSource = libraryUserList;
            ddUserID.DataTextField = "userFullName";
            ddUserID.DataValueField = "userUID";
            ddUserID.DataBind();
        }

        private void dataBindToddUserList()
        {
            BorrowingBooksController borrowingBooksController = new BorrowingBooksControllerImpl();
            List<Book> bookList = new List<Book>();
            Book book = new Book();
            book.bookUID = -1;
            book.Name = "--Select--";
            bookList.Add(book);
            bookList.AddRange(borrowingBooksController.getActiveBookList());
            ddBook.DataSource = bookList;
            ddBook.DataTextField = "Name";
            ddBook.DataValueField = "bookUID";
            ddBook.DataBind();
        }

        private void DisplayMessage(string msg, string color)       // message
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        protected void gvBorrowingBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBorrowingBooks.PageIndex = e.NewPageIndex;          // set new page number
            this.dataBindToBookListGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BorrowingBooksController borrowingBooksController = new BorrowingBooksControllerImpl();

            if (borrowingBooksController.checkIsBookAvailableByBookUID(Int32.Parse(ddBook.SelectedValue)))
            {
            borrowingBooksController.addBorrowingBookRecord(Int32.Parse(ddBook.SelectedValue), Int32.Parse(ddUserID.SelectedValue), DateTime.Parse(txtReturnDate.Text), Session["USER_CODE"].ToString());
            borrowingBooksController.updateBorrowingBookRecord(Int32.Parse(ddBook.SelectedValue), Int32.Parse(ddUserID.SelectedValue), DateTime.Parse(txtReturnDate.Text), Session["USER_CODE"].ToString());
            DisplayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
            }
            else
            {
                DisplayMessage(lblMessage.Text = "Book is not available.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
            }


            this.clearData();
            this.dataBindToBookListGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnSave.Text = "Save";
            this.clearData();
        }

        private void clearData()
        {              // reset all
            txtReturnDate.Text = "";
            ddUserID.SelectedValue = "-1";
            ddBook.SelectedValue = "-1";
            lblQuestion.Text = "";
        }
    }
}