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
    public partial class LibraryUserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {
                this.dataBindToLibraryUserGrid();          // dat bind to grid
                this.dataBindToddUserCategoryList();
                txtUserID.Enabled = false;
                this.loadUserID();
            }
        }

        private void loadUserID() 
        {
            LibraryUserController libraryUserController = new LibraryUserControllerImpl();
            int maxID = libraryUserController.getNextSequenceNo() +1;
            txtUserID.Text = "USR" + maxID.ToString("00000");
        }

        protected void dataBindToLibraryUserGrid()
        {                                  
            LibraryUserController libraryUserController = new LibraryUserControllerImpl();
            ViewState["Library_User_List"] = libraryUserController.findByAll();                        
            gvUser.DataSource = ViewState["Library_User_List"];
            gvUser.DataBind();

            if (gvUser.Rows.Count > 0)      
            {
                hdnUserGridVisible.Value = "1";
            }
            else
            {
                hdnUserGridVisible.Value = "0";     

            }
        }

        private void dataBindToddUserCategoryList()     
        {
            LibraryUserController libraryUserController = new LibraryUserControllerImpl();
            List<LibraryUserCategory> libraryUserCategoryList = new List<LibraryUserCategory>();
            LibraryUserCategory libraryUserCategory = new LibraryUserCategory();
            libraryUserCategory.libraryUserCategoryUID = -1;
            libraryUserCategory.description = "--Select--";
            libraryUserCategoryList.Add(libraryUserCategory);
            libraryUserCategoryList.AddRange(libraryUserController.getActiveLibraryUserCategoryList());
            ddUserCategoryList.DataSource = libraryUserCategoryList;
            ddUserCategoryList.DataTextField = "description";
            ddUserCategoryList.DataValueField = "libraryUserCategoryUID";
            ddUserCategoryList.DataBind();
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
            txtUserID.Text = "";
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtUserNIC.Text = "";
            lblQuestion.Text = "";
            cbxUserActivate.Checked = false;
            ddUserCategoryList.SelectedValue = "-1";
            this.loadUserID();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LibraryUserController libraryUserController = new LibraryUserControllerImpl();
            if (btnSave.Text == "Save")         // if btnSave text equals "Save"
            {
                if (libraryUserController.findByLibraryUserNIC(txtUserNIC.Text.Trim()) == null)   
                {
                    libraryUserController.addLibraryUser(txtUserID.Text.Trim(), txtUserFirstName.Text.Trim(), txtUserLastName.Text.Trim(), txtUserNIC.Text.Trim(), Int32.Parse(ddUserCategoryList.SelectedValue), Session["USER_CODE"].ToString());  // add a record 
                    clearData();                    // clear data fields
                    this.dataBindToLibraryUserGrid();   // reload grid
                    DisplayMessage(lblMessage.Text = "Added Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    DisplayMessage(lblMessage.Text = "User Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }

            }
            else if (btnSave.Text == "Update")
            {     // if btnSave text equals "Update"
                if (libraryUserController.findByLibraryUserNICAndLibraryUserUID(Int32.Parse(hdnUserUID.Value), txtUserNIC.Text.ToString().Trim()) == null)    
                {
                    libraryUserController.editLibraryUser(Int32.Parse(hdnUserUID.Value), txtUserID.Text.Trim(), txtUserFirstName.Text.Trim(), txtUserLastName.Text.Trim(), txtUserNIC.Text.Trim(),int.Parse(ddUserCategoryList.SelectedValue), cbxUserActivate.Checked, Session["USER_CODE"].ToString()); 
                    clearData();                        // clear data fields
                    this.dataBindToLibraryUserGrid();      // reload grid
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

        protected void gvUser_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;          // set new page number
            this.dataBindToLibraryUserGrid();
        }

        protected void gvUser_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);        // get selected row no
            int userUID = Convert.ToInt32(((HiddenField)gvUser.Rows[rowNo].FindControl("userUID")).Value.Trim());  
            List<LibraryUser> libraryUserList = (List<LibraryUser>)ViewState["Library_User_List"];       
            LibraryUser libraryUser = libraryUserList.Find(a => a.userUID == userUID);       
            hdnUserUID.Value = libraryUser.userUID.ToString();     // set data
            txtUserID.Text = libraryUser.userID.ToString();
            txtUserFirstName.Text = libraryUser.firstName.ToString();
            txtUserLastName.Text = libraryUser.lastName.ToString();
            txtUserNIC.Text = libraryUser.NIC.ToString();
            cbxUserActivate.Checked = libraryUser.isActive;
            ddUserCategoryList.SelectedValue = libraryUser.LibraryUserCategoryUID.ToString();

            btnSave.Text = "Update";
            btnReset.Text = "Cancel";
            DisplayQuestion(lblQuestion.Text = "Do you want to Update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
        }
    }
}