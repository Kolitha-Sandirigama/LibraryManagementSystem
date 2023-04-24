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
    public partial class ChangePasswordUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ChangePasswordController changePasswordController = new ChangePasswordControllerImpl();
            LoginUser userLogin = changePasswordController.findByUserLoginID(Session["USER_CODE"].ToString());      // get user login details by login ID

            if (changePasswordController.checkUserLoginByPassword(userLogin, txtOldPassword.Text.Trim()))       //check is old password matched
            {
                if (txtNewPassword.Text.Trim() == txtReEnterNewPassword.Text.Trim())        // if new password correct (enter 2 times and should match them)
                {
                    changePasswordController.updatePasswordByUserLogin(userLogin, txtNewPassword.Text.Trim());          // update password
                    displayMessage(lblMessage.Text = "Password changed.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);

                }
                else
                {
                    displayMessage(lblMessage.Text = "The new password must be the same.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                    txtReEnterNewPassword.Text = "";
                }
            }
            else
            {
                displayMessage(lblMessage.Text = "Invalid Password.Please check and enter current password again.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtReEnterNewPassword.Text = "";
            lblMessage.Text = "";
        }

        private void displayMessage(string msg, string color)       // message
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }
    }
}