using MasterDataUt.Controller;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationWeb.TransactionWeb
{
    public partial class ReturningBooks : System.Web.UI.Page
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
            ReturningBooksController returningBooksController = new ReturningBooksControllerImpl();
            ViewState["Book_List"] = returningBooksController.findByAll();
            gvreturningBooks.DataSource = ViewState["Book_List"];
            gvreturningBooks.DataBind();

            if (gvreturningBooks.Rows.Count > 0)
            {
                hdnReturningingBookGridVisible.Value = "1";
            }
            else
            {
                hdnReturningingBookGridVisible.Value = "0";

            }
        }

        private void dataBindToddBookList()
        {
            ReturningBooksController returningBooksController = new ReturningBooksControllerImpl();
            List<LibraryUser> libraryUserList = new List<LibraryUser>();
            LibraryUser libraryUser = new LibraryUser();
            libraryUser.userUID = -1;
            libraryUser.userFullName = "--Select--";
            libraryUserList.Add(libraryUser);
            libraryUserList.AddRange(returningBooksController.getActiveUserList());
            ddUserID.DataSource = libraryUserList;
            ddUserID.DataTextField = "userFullName";
            ddUserID.DataValueField = "userUID";
            ddUserID.DataBind();
        }

        private void dataBindToddUserList()
        {
            ReturningBooksController returningBooksController = new ReturningBooksControllerImpl();
            List<Book> bookList = new List<Book>();
            Book book = new Book();
            book.bookUID = -1;
            book.Name = "--Select--";
            bookList.Add(book);
            bookList.AddRange(returningBooksController.getActiveBookList());
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ReturningBooksController returningBooksController = new ReturningBooksControllerImpl();


            returningBooksController.addReturningBookRecord(Int32.Parse(ddBook.SelectedValue), Int32.Parse(ddUserID.SelectedValue), Session["USER_CODE"].ToString());
            returningBooksController.updateReturningBookRecord(Int32.Parse(ddBook.SelectedValue), Int32.Parse(ddUserID.SelectedValue), Session["USER_CODE"].ToString());
            DisplayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);

            this.clearData();
            this.dataBindToBookListGrid();
        }

        protected void gvreturningBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvreturningBooks.PageIndex = e.NewPageIndex;          // set new page number
            this.dataBindToBookListGrid();
        }

        private void clearData() 
        { 
            ddUserID.SelectedValue = "-1";
            ddBook.SelectedValue = "-1";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            this.clearData();
        }
    }
}