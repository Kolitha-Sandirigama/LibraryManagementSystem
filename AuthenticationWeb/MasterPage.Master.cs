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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public String UserId
        {
            get { return (String)Session["USER_CODE"]; }
            set { Session["USER_CODE"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_CODE"] != null)
            {
                LoginUser User = new LoginUser();
                User.UserName = Session["USER_CODE"].ToString();
                if (User.UserName.Length > 10)
                {
                    lblName.Text = User.UserName.Substring(0, 9).ToString();
                }
                else
                {
                    lblName.Text = User.UserName.ToString();

                }

                hdnUserCode.Value = Session["USER_CODE"].ToString();
            }
            else
            {
                Response.Redirect("UserLogin.aspx");
            }

        }

        protected void ContentPlaceHolder1_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (hdnUserCode.Value.Length > 0)
                {
                    Session["USER_CODE"] = hdnUserCode.Value;
                }
            }
        }

        protected void ContentPlaceHolder1_Unload(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginUser User = new LoginUser();
                if (Session["USER_CODE"] != null)
                {
                    User.UserName = Session["USER_CODE"].ToString();
                    lblName.Text = User.UserName.ToString();
                }

                #region Check Authority
                if (Session["USER_CODE"] != null)
                {

                    hdnUserCode.Value = Session["USER_CODE"].ToString();

                    List<Functions> FunctionsList = null;

                    if (ViewState["FunctionList"] == null)
                    {
                        //get funtion list

                        FunctionController functionController = new FunctionControllerImpl();

       //                 Functions Functions = new Functions();
       //                 Functions.UserCode = hdnUserCode.Value;
                        FunctionsList = functionController.GetUserFunctionCodeList(hdnUserCode.Value);

                        if (FunctionsList.Count > 0)
                        {
                            if (!Page.AppRelativeVirtualPath.Equals(""))
                            {
                                string[] pageContent = Page.AppRelativeVirtualPath.Split('/');
                                string loadingPage = pageContent[pageContent.Length - 1].Split('?')[0];
                                if (loadingPage.Equals("ErrorPage.aspx"))
                                {
                                    return;
                                }
                                else
                                {

                                    if (functionController.GetFunctionCodeByPageName(loadingPage) != 0)
                                    {
                                        int pageCode = functionController.GetFunctionCodeByPageName(loadingPage);

                                        if (!FunctionsList.Exists(delegate(Functions func) { return func.FunctionUID == pageCode; }))
                                        {
                                            System.Web.HttpContext.Current.Response.Redirect("/NoPermission.aspx");
                                        }

                                    }
                                    else
                                    {
                                        if (!loadingPage.Equals("NoPermission.aspx"))
                                        {
                                            System.Web.HttpContext.Current.Response.Redirect("/NoPermission.aspx");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                System.Web.HttpContext.Current.Response.Redirect("/NoPermission.aspx");

                            }
                        }
                        else
                        {
                            string[] pageContentError = Page.AppRelativeVirtualPath.Split('/');
                            string loadingPageError = pageContentError[pageContentError.Length - 1].Split('?')[0];
                            if (loadingPageError.Equals("NoPermission.aspx"))
                            {
                                return;
                            }
                            else
                            {
                                System.Web.HttpContext.Current.Response.Redirect("/NoPermission.aspx");
                            }
                        }
                        
                    }
                    else
                    {                        
                            System.Web.HttpContext.Current.Response.Redirect("/ErrorPage.aspx");                        
                    }                    
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Redirect("UserLogin.aspx");
                }
                #endregion


            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserLogin.aspx");
        }

        protected void lbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemDashBoard.aspx");
        }

    }
}