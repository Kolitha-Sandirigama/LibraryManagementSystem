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
    public partial class RoleFunctions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;  // disable the use of unobtrusive JavaScript for client - side validation

            if (!Page.IsPostBack)
            {
                this.dataBindToRole();
                this.dataBindToAllFunctionsListBox(Convert.ToInt32(ddRole.SelectedValue));
                this.dataBindToSelectedFunctionsListBox(Convert.ToInt32(ddRole.SelectedValue));
                this.dataBindToGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<SystemFunction> selectedFunctionList = (List<SystemFunction>)ViewState["SELECTED_FUNCTIONS"];
            if (ddRole.SelectedValue == "-1")
            {
                displayMessage(lblMessage.Text = "Please select a role.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
            }
            else
            {
                RoleFunctionsController roleFunctionsController = new RoleFunctionsControllerImpl();
                roleFunctionsController.saveRoleFuntions(Convert.ToInt32(ddRole.SelectedValue), selectedFunctionList, Session["USER_CODE"].ToString());
                displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                ViewState["ALL_FUNCTIONS"] = null;
                ViewState["SELECTED_FUNCTIONS"] = null;
                lbSelectedFunctions.Items.Clear();
                lbAllFunctions.Items.Clear();
                lblMessage.Text = "";
                ddRole.SelectedValue = "-1";
                this.dataBindToGrid();
            }
        }

        protected void gvRoleFunctions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoleFunctions.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }


        private void dataBindToRole()
        {
            RoleFunctionsController roleFunctionsController = new RoleFunctionsControllerImpl();
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.roleUID = -1;
            role.name = "--Select--";
            roleList.Add(role);
            roleList.AddRange(roleFunctionsController.getActiveRole());
            ddRole.DataTextField = "name";
            ddRole.DataValueField = "roleUID";
            ddRole.DataSource = roleList;
            ddRole.DataBind();
        }

        private void dataBindToAllFunctionsListBox(int roleUID)
        {

            lbAllFunctions.Items.Clear();
            ViewState["ALL_FUNCTIONS"] = null;
            if (Convert.ToInt32(roleUID) != -1)
            {
                RoleFunctionsController roleFunctionsController = new RoleFunctionsControllerImpl();
                ViewState["ALL_FUNCTIONS"] = roleFunctionsController.getAllFunctionListByRole(roleUID);
                List<SystemFunction> allFunctionList = (List<SystemFunction>)ViewState["ALL_FUNCTIONS"];
                foreach (SystemFunction function in allFunctionList)
                {
                    lbAllFunctions.Items.Add(function.description);
                }
            }
        }

        private void dataBindToSelectedFunctionsListBox(int roleUID)
        {
            lbSelectedFunctions.Items.Clear();
            ViewState["SELECTED_FUNCTIONS"] = null;
            if (Convert.ToInt32(roleUID) != -1)
            {
                RoleFunctionsController roleFunctionsController = new RoleFunctionsControllerImpl();
                ViewState["SELECTED_FUNCTIONS"] = roleFunctionsController.getSelectedFunctionListByRole(roleUID);
                List<SystemFunction> selectedFunctionList = (List<SystemFunction>)ViewState["SELECTED_FUNCTIONS"];
                foreach (SystemFunction function in selectedFunctionList)
                {
                    lbSelectedFunctions.Items.Add(function.description);
                }
            }
        }

        private void dataBindToGrid()
        {
            RoleFunctionsController roleFunctionsController = new RoleFunctionsControllerImpl();
            gvRoleFunctions.DataSource = roleFunctionsController.getRoleFunctionListByRole(Convert.ToInt32(ddRole.SelectedValue));
            gvRoleFunctions.DataBind();

            if (gvRoleFunctions.Rows.Count > 0)
            {
                hdnRoleFunctionGridVisible.Value = "1";
            }
            else
            {
                hdnRoleFunctionGridVisible.Value = "0";
            }
        }

        private void displayMessage(string msg, string color)
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ViewState["ALL_FUNCTIONS"] = null;
            ViewState["SELECTED_FUNCTIONS"] = null;
            lbSelectedFunctions.Items.Clear();
            lbAllFunctions.Items.Clear();
            lblMessage.Text = "";
            ddRole.SelectedValue = "-1";
            this.dataBindToGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<SystemFunction> allFunctionList = (List<SystemFunction>)ViewState["ALL_FUNCTIONS"];
            List<SystemFunction> selectedFunctionList = (List<SystemFunction>)ViewState["SELECTED_FUNCTIONS"];

            foreach (ListItem lst in lbAllFunctions.Items)
            {
                if (lst.Selected == true)
                {
                    lbSelectedFunctions.Items.Add(lst.Text);
                    SystemFunction systemFunction = allFunctionList.Find(a => a.description == lst.Text);
                    selectedFunctionList.Add(systemFunction);
                    allFunctionList.Remove(systemFunction);
                }
            }

            lbAllFunctions.Items.Clear();
            foreach (SystemFunction systemFunction in allFunctionList)
            {
                lbAllFunctions.Items.Add(systemFunction.description);
            }

            ViewState["ALL_FUNCTIONS"] = allFunctionList;
            ViewState["SELECTED_FUNCTIONS"] = selectedFunctionList;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            List<SystemFunction> allFunctionList = (List<SystemFunction>)ViewState["ALL_FUNCTIONS"];
            List<SystemFunction> selectedFunctionList = (List<SystemFunction>)ViewState["SELECTED_FUNCTIONS"];

            foreach (ListItem lst in lbSelectedFunctions.Items)
            {
                if (lst.Selected == true)
                {
                    lbAllFunctions.Items.Add(lst.Text);
                    SystemFunction systemFunction = selectedFunctionList.Find(a => a.description == lst.Text);
                    allFunctionList.Add(systemFunction);
                    selectedFunctionList.Remove(systemFunction);
                }
            }

            lbSelectedFunctions.Items.Clear();
            foreach (SystemFunction systemFunction in selectedFunctionList)
            {
                lbSelectedFunctions.Items.Add(systemFunction.description);
            }

            ViewState["ALL_FUNCTIONS"] = allFunctionList;
            ViewState["SELECTED_FUNCTIONS"] = selectedFunctionList;
        }

        protected void ddRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ALL_FUNCTIONS"] = null;
            ViewState["SELECTED_FUNCTIONS"] = null;
            lbAllFunctions.Items.Clear();
            lbSelectedFunctions.Items.Clear();
            this.dataBindToAllFunctionsListBox(Convert.ToInt32(ddRole.SelectedValue));
            this.dataBindToSelectedFunctionsListBox(Convert.ToInt32(ddRole.SelectedValue));
            this.dataBindToGrid();
        }
    }
}