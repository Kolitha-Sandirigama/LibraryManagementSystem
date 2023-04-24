using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationUt.Controller;
using AuthenticationUt.Domain;

namespace LibrarySystemWeb
{
    public partial class SystemFunctions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;  // disable the use of unobtrusive JavaScript for client - side validation

            if (!Page.IsPostBack)
            {
                this.dataBindToGrid();
            }
        }

        private void dataBindToGrid()
        {
            SystemFunctionsController systemFunctionsController = new SystemFunctionsControllerImpl();
            ViewState["SYSTEM_FUNCTIONS"] = systemFunctionsController.getAllFunctions();
            gvSystemFunctions.DataSource = ViewState["SYSTEM_FUNCTIONS"];
            gvSystemFunctions.DataBind();

            if (gvSystemFunctions.Rows.Count > 0)
            {
                hdnSystemFunctionGridVisible.Value = "1";
            }
            else
            {
                hdnSystemFunctionGridVisible.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemFunctionsController systemFunctionsController = new SystemFunctionsControllerImpl();

            if (btnSave.Text == "Save")
            {
                if (!systemFunctionsController.checkIsExistsByFunctionName(txtDescription.Text.Trim().ToString()))
                {
                    systemFunctionsController.addFunction(txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
                    displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    displayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else if (btnSave.Text == "Update")
            {
                systemFunctionsController.updateFunction(Convert.ToInt32(hdnSystemFunctionUID.Value), txtDescription.Text.ToString(), txtNotes.Text.ToString(), cbIsActivate.Checked, Session["USER_CODE"].ToString());
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

        protected void gvSystemFunctions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSystemFunctions.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }

        protected void gvSystemFunctions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);
            int functionUID = Convert.ToInt32(((HiddenField)gvSystemFunctions.Rows[rowNo].FindControl("SystemFunctionUID")).Value.Trim());
            List<SystemFunction> SystemFunctionList = (List<SystemFunction>)ViewState["SYSTEM_FUNCTIONS"];
            SystemFunction systemFunction = SystemFunctionList.Find(a => a.systemFunctionUID == functionUID);
            hdnSystemFunctionUID.Value = systemFunction.systemFunctionUID.ToString();
            txtDescription.Text = systemFunction.description.ToString();
            txtNotes.Text = systemFunction.notes.ToString();
            cbIsActivate.Checked = systemFunction.isActive;

            txtDescription.Enabled = false;

            btnSave.Text = "Update";
            displayQuestion(lblQuestion.Text = "Do you want to update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);

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

    }
}