using AuthenticationUt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationUt.Controller;


namespace LibrarySystemWeb
{
    public partial class RoleManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;  // disable the use of unobtrusive JavaScript for client - side validation
            this.dataBindToGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";

            if (txtName.Text.Trim() != "")
            {
                RoleController roleController = new RoleControllerImpl();
                if (btnSave.Text == "Save")
                {
                    if (!roleController.getIsExistByName(txtName.Text.Trim().ToString()))
                    {
                        roleController.addRole(txtName.Text.ToString().Trim(), cbisActive.Checked, Session["USER_CODE"].ToString());
                        displayMessage(lblMessage.Text = "Updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                    }
                    else
                    {
                        displayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    if (!roleController.getIsExistByNameAndRoleUID(txtName.Text.Trim().ToString(), Convert.ToInt32(hdnRoleUID.Value)))
                    {
                        roleController.updateRole(Convert.ToInt32(hdnRoleUID.Value), txtName.Text.ToString().Trim(), cbisActive.Checked, Session["USER_CODE"].ToString());
                        displayMessage(lblMessage.Text = "Updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                    }
                    else
                    {
                        displayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                    }
                }
                this.dataBindToGrid();
                lblQuestion.Text = "";
                btnSave.Text = "Save";
                txtName.Text = "";
                cbisActive.Checked = false;
            }
            else
            {
                displayMessage(lblMessage.Text = "Please Enter a name.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
            }
        }

        protected void gvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRole.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }

        protected void gvRole_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);
            int roleUID = Convert.ToInt32(((HiddenField)gvRole.Rows[rowNo].FindControl("RoleUID")).Value.Trim());
            List<Role> roleList = (List<Role>)ViewState["Role"];
            Role role = roleList.Find(a => a.roleUID == roleUID);
            hdnRoleUID.Value = role.roleUID.ToString();
            txtName.Text = role.name.ToString();
            cbisActive.Checked = role.isActive;


            btnSave.Text = "Update";
            displayQuestion(lblQuestion.Text = "Do you want to update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);

        }

        private void displayMessage(string msg, string color)
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void displayQuestion(string msg, string color)
        {
            lblQuestion.Text = msg;
            lblQuestion.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void dataBindToGrid()
        {
            RoleController RoleController = new RoleControllerImpl();
            ViewState["Role"] = RoleController.getAllRole();
            gvRole.DataSource = ViewState["Role"];
            gvRole.DataBind();

            if (gvRole.Rows.Count > 0)
            {
                hdnRoleGridVisible.Value = "1";
            }
            else
            {
                hdnRoleGridVisible.Value = "0";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cbisActive.Checked = false;
            lblMessage.Text = "";
            lblQuestion.Text = "";
            btnSave.Text = "Save";
        }
    }
}