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
    public partial class LibraryUserCategoryManagement : System.Web.UI.Page
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
            LibraryUserCategoryController libraryUserCategoryController = new LibraryUserCategoryControllerImpl();
            ViewState["LIBRARY_USER_CATEGORIES"] = libraryUserCategoryController.getAllLibraryUserCategories();
            gvLibraryUserCategory.DataSource = ViewState["LIBRARY_USER_CATEGORIES"];
            gvLibraryUserCategory.DataBind();

            if (gvLibraryUserCategory.Rows.Count > 0)
            {
                hdnLibraryUserCategoryGridVisible.Value = "1";
            }
            else
            {
                hdnLibraryUserCategoryGridVisible.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LibraryUserCategoryController libraryUserCategoryController = new LibraryUserCategoryControllerImpl();

            if (btnSave.Text == "Save")
            {
                if (!libraryUserCategoryController.checkIsExistsByLibraryUserCategoryName(txtDescription.Text.Trim().ToString()))
                {
                    libraryUserCategoryController.addLibraryUserCategory(txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
                    displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    displayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else if (btnSave.Text == "Update")
            {
                libraryUserCategoryController.updateLibraryUserCategory(Convert.ToInt32(hdnLibraryUserCategoryUID.Value), txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
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

        protected void gvLibraryUserCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLibraryUserCategory.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }

        protected void gvLibraryUserCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);
            int libraryUserCategoryUID = Convert.ToInt32(((HiddenField)gvLibraryUserCategory.Rows[rowNo].FindControl("libraryUserCategoryUID")).Value.Trim());
            List<LibraryUserCategory> libraryUserCategoryList = (List<LibraryUserCategory>)ViewState["LIBRARY_USER_CATEGORIES"];
            LibraryUserCategory libraryUserCategory = libraryUserCategoryList.Find(a => a.libraryUserCategoryUID == libraryUserCategoryUID);
            hdnLibraryUserCategoryUID.Value = libraryUserCategory.libraryUserCategoryUID.ToString();
            txtDescription.Text = libraryUserCategory.description.ToString();
            txtNotes.Text = libraryUserCategory.notes.ToString();
            cbIsActivate.Checked = libraryUserCategory.isActive;

            txtDescription.Enabled = false;

            btnSave.Text = "Update";
            displayQuestion(lblQuestion.Text = "Do you want to update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
        }
    }
}