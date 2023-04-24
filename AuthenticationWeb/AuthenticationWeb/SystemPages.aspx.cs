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
    public partial class SystemPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;  // disable the use of unobtrusive JavaScript for client - side validation

            if (!Page.IsPostBack)
            {
                this.dataBindToGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemPagesController systemPagesController = new SystemPagesControllerImpl();
            systemPagesController.addSystemPage(txtPageName.Text.ToString(), txtURL.Text.Trim().ToString(), txtDescription.Text.ToString(), Session["USER_CODE"].ToString());
            displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
            this.dataBindToGrid();
            txtURL.Text = "";
            txtPageName.Text = "";
            txtDescription.Text = "";
        }

        private void dataBindToGrid()
        {
            SystemPagesController systemPagesController = new SystemPagesControllerImpl();
            gvSystemPages.DataSource = systemPagesController.getSystemPagesByAll();
            gvSystemPages.DataBind();

            if (gvSystemPages.Rows.Count > 0)
            {
                hdnsystemPagesGridVisible.Value = "1";
            }
            else
            {
                hdnsystemPagesGridVisible.Value = "0";
            }
        }

        private void displayMessage(string msg, string color)
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtPageName.Text = "";
            txtURL.Text = "";
            lblMessage.Text = "";
            this.dataBindToGrid();
        }

        protected void gvSystemPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSystemPages.PageIndex = e.NewPageIndex;
            this.dataBindToGrid();
        }
    }
}