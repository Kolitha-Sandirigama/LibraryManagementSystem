using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationUt.Domain;
using AuthenticationUt.Controller;

namespace LibrarySystemWeb
{
    public partial class SystemPageRoleFunctionManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                this.dataBindToddFunction();
                this.dataBindToAllPageslistBox(Convert.ToInt32(ddFunction.SelectedValue));
                this.dataBindToSelectedPageslistBox(Convert.ToInt32(ddFunction.SelectedValue));
                this.DataBindToGrid();
            }
        }

        protected void ddFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            this.dataBindToAllPageslistBox(Convert.ToInt32(ddFunction.SelectedValue));
            this.dataBindToSelectedPageslistBox(Convert.ToInt32(ddFunction.SelectedValue));
            this.DataBindToGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<SystemPage> allSystemPageList = (List<SystemPage>)ViewState["ALL_PAGES"];
            List<SystemPage> selectedSystemPageList = (List<SystemPage>)ViewState["SELECTED_PAGES"];

            foreach (ListItem lst in lbAllPages.Items)
            {
                if (lst.Selected == true)
                {
                    lbSelectedPages.Items.Add(lst.Text);
                    SystemPage systemPage = allSystemPageList.Find(a => a.systemPageName == lst.Text);
                    selectedSystemPageList.Add(systemPage);
                    allSystemPageList.Remove(systemPage);
                }
            }

            lbAllPages.Items.Clear();
            foreach (SystemPage page in allSystemPageList)
            {
                lbAllPages.Items.Add(page.systemPageName);
            }

            ViewState["ALL_PAGES"] = allSystemPageList;
            ViewState["SELECTED_PAGES"] = selectedSystemPageList;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            List<SystemPage> allPageList = (List<SystemPage>)ViewState["ALL_PAGES"];
            List<SystemPage> selectedPageList = (List<SystemPage>)ViewState["SELECTED_PAGES"];

            foreach (ListItem lst in lbSelectedPages.Items)
            {
                if (lst.Selected == true)
                {
                    lbAllPages.Items.Add(lst.Text);
                    SystemPage systemPage = selectedPageList.Find(a => a.systemPageName == lst.Text);
                    allPageList.Add(systemPage);
                    selectedPageList.Remove(systemPage);
                }

            }

            lbSelectedPages.Items.Clear();
            foreach (SystemPage page in selectedPageList)
            {
                lbSelectedPages.Items.Add(page.systemPageName);
            }

            ViewState["ALL_PAGES"] = allPageList;
            ViewState["SELECTED_PAGES"] = selectedPageList;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<SystemPage> selectedPageList = (List<SystemPage>)ViewState["SELECTED_PAGES"];
            SystemPageRoleFunctionManagementController systemPageRoleFunctionManagementController = new SystemPageRoleFunctionManagementControllerImpl();
            systemPageRoleFunctionManagementController.addSystemPageFunction(Convert.ToInt32(ddFunction.SelectedValue), selectedPageList, Session["USER_CODE"].ToString());
            ddFunction.SelectedValue = "-1";
            lbAllPages.Items.Clear();
            lbSelectedPages.Items.Clear();
            ViewState["ALL_PAGES"] = null;
            ViewState["SELECTED_PAGES"] = null;
            this.DataBindToGrid();
            displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddFunction.SelectedValue = "-1";
            lblMessage.Text = "";
            lbAllPages.Items.Clear();
            lbSelectedPages.Items.Clear();
            ViewState["ALL_PAGES"] = null;
            ViewState["SELECTED_PAGES"] = null;
        }

        protected void gvSystemPageFunctions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSystemPageFunctions.PageIndex = e.NewPageIndex;
            this.DataBindToGrid();
        }

        private void dataBindToddFunction()
        {
            SystemPageRoleFunctionManagementController systemPageRoleFunctionManagementController = new SystemPageRoleFunctionManagementControllerImpl();
            List<SystemFunction> systemFunctionList = new List<SystemFunction>();
            SystemFunction systemFunction = new SystemFunction();
            systemFunction.systemFunctionUID = -1;
            systemFunction.description = "--Select--";
            systemFunctionList.Add(systemFunction);
            systemFunctionList.AddRange(systemPageRoleFunctionManagementController.getsystemFunctions());
            ddFunction.DataTextField = "description";
            ddFunction.DataValueField = "systemFunctionUID";
            ddFunction.DataSource = systemFunctionList;
            ddFunction.DataBind();
        }

        private void dataBindToAllPageslistBox(int functionUID)
        {
            lbAllPages.Items.Clear();
            ViewState["ALL_PAGES"] = null;
            if (Convert.ToInt32(functionUID) != -1)
            {
                SystemPageRoleFunctionManagementController systemPageRoleFunctionManagementController = new SystemPageRoleFunctionManagementControllerImpl();
                ViewState["ALL_PAGES"] = systemPageRoleFunctionManagementController.getAllPageListByFuncionUID(functionUID);
                List<SystemPage> allSystemPageList = (List<SystemPage>)ViewState["ALL_PAGES"];
                foreach (SystemPage page in allSystemPageList)
                {
                    lbAllPages.Items.Add(page.systemPageName);
                }
            }
        }

        private void dataBindToSelectedPageslistBox(int functionUID)
        {
            lbSelectedPages.Items.Clear();
            ViewState["SELECTED_PAGES"] = null;
            if (Convert.ToInt32(functionUID) != -1)
            {
                SystemPageRoleFunctionManagementController systemPageRoleFunctionManagementController = new SystemPageRoleFunctionManagementControllerImpl();
                ViewState["SELECTED_PAGES"] = systemPageRoleFunctionManagementController.getSelectedPageListByFuncionUID(functionUID);
                List<SystemPage> selectedSystemPageList = (List<SystemPage>)ViewState["SELECTED_PAGES"];
                foreach (SystemPage page in selectedSystemPageList)
                {
                    lbSelectedPages.Items.Add(page.systemPageName);
                }
            }
        }


        private void DataBindToGrid()
        {
            SystemPageRoleFunctionManagementController systemPageRoleFunctionManagementController = new SystemPageRoleFunctionManagementControllerImpl();
            gvSystemPageFunctions.DataSource = systemPageRoleFunctionManagementController.getSystemPageFunctionListByFunctionUID(Convert.ToInt32(ddFunction.SelectedValue));
            gvSystemPageFunctions.DataBind();

            if (gvSystemPageFunctions.Rows.Count > 0)
            {
                hdnPageFunctionGridVisible.Value = "1";
            }
            else
            {
                hdnPageFunctionGridVisible.Value = "0";
            }
        }

        private void displayMessage(string msg, string color)
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

    }
}