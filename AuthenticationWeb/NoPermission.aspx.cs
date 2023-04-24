using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystemWeb
{
    public partial class NoPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;  // disable the use of unobtrusive JavaScript for client - side validation

            if (!Page.IsPostBack)
            {

            }
        }
    }
}