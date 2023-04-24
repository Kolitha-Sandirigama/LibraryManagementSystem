using System;
using System.Web.UI;
using AuthenticationUt.Domain;
using AuthenticationUt.Controller;

namespace LibrarySystemWeb
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["USER_CODE"] = null;
            Session["BUSINESS_UNIT_CODE"] = null;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserLoginControllerImpl userLoginController = new UserLoginControllerImpl();
            LoginUser userLogin = userLoginController.findByUserLoginID(txtUserName.Text.Trim());           // get user login by user name
            if (userLogin != null && userLogin.UserLoginID > 0)         // if user login exists & loginUID > 0
            {
                if (userLoginController.checkUserLoginByPassword(userLogin, txtPassword.Text.Trim()))       // validate password by user login details and entered password
                {
                    Session["USER_CODE"] = userLogin.UserName;
                    Session["BUSINESS_UNIT_CODE"] = userLogin.UserLoginID;

                    Response.Redirect("SystemDashBoard.aspx");
                }
                else 
                {
                    DisplayMessage(lblMessage.Text = "Invalid UserName or Password.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else 
            { 
                DisplayMessage(lblMessage.Text="Invalid User.Please check and try again.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
            }
        }


        private void DisplayMessage(string msg, string color)       // message method
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

    }
}