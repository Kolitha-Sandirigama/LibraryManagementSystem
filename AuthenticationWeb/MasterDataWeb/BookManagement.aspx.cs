using MasterDataUt.Controller;
using MasterDataUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationWeb.MasterDataWeb
{
    public partial class BookManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {
                this.dataBindToBookListGrid();          // dat bind to grid
                this.dataBindToddBookCategoryList();
                txtBookID.Enabled = false;
                this.loadBookID();
            }
        }

        private void loadBookID()
        {
            BookController bookController = new BookControllerImpl();
            int maxID = bookController.getNextSequenceNo() + 1;
            txtBookID.Text = "BOK" + maxID.ToString("00000");
        }

        protected void dataBindToBookListGrid()
        {
            BookController bookController = new BookControllerImpl();
            ViewState["BooK_List"] = bookController.findByAll();
            gvBookList.DataSource = ViewState["BooK_List"];
            gvBookList.DataBind();

            if (gvBookList.Rows.Count > 0)
            {
                hdnBookListGridVisible.Value = "1";
            }
            else
            {
                hdnBookListGridVisible.Value = "0";

            }
        }

        private void dataBindToddBookCategoryList()
        {
            BookController bookController = new BookControllerImpl();
            List<BookCategory> bookCategoryList = new List<BookCategory>();
            BookCategory bookCategory = new BookCategory();
            bookCategory.bookCategoryUID = -1;
            bookCategory.description = "--Select--";
            bookCategoryList.Add(bookCategory);
            bookCategoryList.AddRange(bookController.getActiveBookCategoryList());
            ddBookCategoryList.DataSource = bookCategoryList;
            ddBookCategoryList.DataTextField = "description";
            ddBookCategoryList.DataValueField = "bookCategoryUID";
            ddBookCategoryList.DataBind();
        }

        private void DisplayMessage(string msg, string color)       // message
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void DisplayQuestion(string msg, string color)      // question
        {
            lblQuestion.Text = msg;
            lblQuestion.Style.Add(HtmlTextWriterStyle.Color, color);
        }


        private void clearData()
        {              // reset all
            txtBookID.Text = "";
            txtName.Text = "";
            txtAuthorName.Text = "";
            txtISBNNo.Text = "";
            lblQuestion.Text = "";
            cbxActivate.Checked = false;
            ddBookCategoryList.SelectedValue = "-1";
            this.loadBookID();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BookController bookController = new BookControllerImpl();
            if (btnSave.Text == "Save")         // if btnSave text equals "Save"
            {
                if (bookController.findByBookISBN(txtISBNNo.Text.Trim()) == null)
                {
                    bookController.addBook(txtBookID.Text.Trim(), txtName.Text.Trim(), txtAuthorName.Text.Trim(), txtISBNNo.Text.Trim(), Int32.Parse(ddBookCategoryList.SelectedValue), Session["USER_CODE"].ToString());  // add a record 
                    clearData();                    // clear data fields
                    this.dataBindToBookListGrid();   // reload grid
                    DisplayMessage(lblMessage.Text = "Added Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    DisplayMessage(lblMessage.Text = "Book Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }

            }
            else if (btnSave.Text == "Update")
            {     // if btnSave text equals "Update"
                if (bookController.findByBookISBNAndBookUID(Int32.Parse(hdnBookUID.Value), txtISBNNo.Text.ToString().Trim()) == null)
                {
                    bookController.editBook(Int32.Parse(hdnBookUID.Value), txtBookID.Text.Trim(), txtName.Text.Trim(), txtAuthorName.Text.Trim(), txtISBNNo.Text.Trim(), int.Parse(ddBookCategoryList.SelectedValue), cbxActivate.Checked, Session["USER_CODE"].ToString());
                    clearData();                        // clear data fields
                    this.dataBindToBookListGrid();      // reload grid
                    DisplayMessage(lblMessage.Text = "Updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    DisplayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
                clearData();        // clear data fields
                btnSave.Text = "Save";  // reset btnSave button text 
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnSave.Text = "Save";
            this.clearData();
        }

        protected void gvBookList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);        // get selected row no
            int bookUID = Convert.ToInt32(((HiddenField)gvBookList.Rows[rowNo].FindControl("bookUID")).Value.Trim());
            List<Book> bookList = (List<Book>)ViewState["BooK_List"];
            Book book = bookList.Find(a => a.bookUID == bookUID);
            hdnBookUID.Value = book.bookUID.ToString();     // set data
            txtBookID.Text = book.bookID.ToString();
            txtName.Text = book.Name.ToString();
            txtAuthorName.Text = book.Author.ToString();
            txtISBNNo.Text = book.ISBNNo.ToString();
            cbxActivate.Checked = book.isActive;
            ddBookCategoryList.SelectedValue = book.bookCategoryUID.ToString();

            btnSave.Text = "Update";
            btnReset.Text = "Cancel";
            DisplayQuestion(lblQuestion.Text = "Do you want to Update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
        }

        protected void gvBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookList.PageIndex = e.NewPageIndex;          // set new page number
            this.dataBindToBookListGrid();
        }
    }
}