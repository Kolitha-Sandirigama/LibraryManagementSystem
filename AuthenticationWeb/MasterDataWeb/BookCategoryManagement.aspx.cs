using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterDataUt.Controller;
using MasterDataUt.Domain;

namespace AuthenticationWeb.MasterDataWeb
{
    public partial class BookCategoryManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {
                this.dataBindToGrid();
            }
        }

        private void dataBindToGrid()
        {
            BookCategoryController bookCategoryController = new BookCategoryControllerImpl();
            ViewState["BOOK_CATEGORIES"] = bookCategoryController.getAllBookCategories();
            gvBookCategory.DataSource = ViewState["BOOK_CATEGORIES"];
            gvBookCategory.DataBind();

            if (gvBookCategory.Rows.Count > 0)
            {
                hdnBookCategoryGridVisible.Value = "1";
            }
            else
            {
                hdnBookCategoryGridVisible.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BookCategoryController bookCategoryController = new BookCategoryControllerImpl();

            if (btnSave.Text == "Save")
            {
                if (!bookCategoryController.checkIsExistsByBookCategoryName(txtDescription.Text.Trim().ToString()))
                {
                    bookCategoryController.addBookCategory(txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
                    displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    displayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else if (btnSave.Text == "Update")
            {
                bookCategoryController.updateBookCategory(Convert.ToInt32(hdnBookCategoryUID.Value), txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
                displayMessage(lblMessage.Text = "updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
            }

            btnSave.Text = "Save";
            lblQuestion.Text = "";
            txtDescription.Text = "";
            txtNotes.Text = "";
            cbIsActivate.Checked = false;
            txtDescription.Enabled = true;
            this.dataBindToGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            txtDescription.Text = "";
            txtNotes.Text = "";
            txtDescription.Enabled = true;
            cbIsActivate.Checked = false;
            lblMessage.Text = "";
            lblQuestion.Text = "";
        }

        private void displayQuestion(string msg, string color)
        {
            lblQuestion.Text = msg;
            lblQuestion.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void displayMessage(string msg, string color)
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        protected void gvBookCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookCategory.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }

        protected void gvBookCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);
            int bookCategoryUID = Convert.ToInt32(((HiddenField)gvBookCategory.Rows[rowNo].FindControl("BookCategoryUID")).Value.Trim());
            List<BookCategory> BookCategoryList = (List<BookCategory>)ViewState["BOOK_CATEGORIES"];
            BookCategory bookCategory = BookCategoryList.Find(a => a.bookCategoryUID == bookCategoryUID);
            hdnBookCategoryUID.Value = bookCategory.bookCategoryUID.ToString();
            txtDescription.Text = bookCategory.description.ToString();
            txtNotes.Text = bookCategory.notes.ToString();
            cbIsActivate.Checked = bookCategory.isActive;

            txtDescription.Enabled = false;

            btnSave.Text = "Update";
            displayQuestion(lblQuestion.Text = "Do you want to update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
        }
    }
}