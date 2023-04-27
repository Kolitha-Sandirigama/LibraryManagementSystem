using MasterDataUt.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystemWeb
{
    public partial class SystemDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DashBoardController DashBoardController = new DashBoardControllerImpl();
            lblTotalBooks.Text = DashBoardController.getTotalActiveBookCount().ToString();
            lblAvailableBooks.Text = DashBoardController.getTotalAvailableBookCount().ToString();
            lblBorrowingBooks.Text = DashBoardController.getTotalBorrowedBookCount().ToString();
            lblTotalUsers.Text = DashBoardController.getTotalActiveUserCount().ToString();


        }
    }
}