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
    public partial class EmployeeRoleManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!IsPostBack)
            {
                this.dataBindToddRoleList();            // data bind to role drop down
                this.dataBindToddEmployeeList();        // data bind to Employee drop down
                this.dataBindToGrid();                  // data bind to grid
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeRoleController employeeRoleController = new EmployeeRoleControllerImpl();
            if (btnSave.Text == "Save")  //if btnSave button text equals to "Save"
            {
                if (!employeeRoleController.isEmployeeRoleExists(Convert.ToInt32(ddEmployeeList.SelectedValue), Convert.ToInt32(ddRoleList.SelectedValue)))         // if the mapping already exists
                {
                    employeeRoleController.addEmployeeRole(Convert.ToInt32(ddEmployeeList.SelectedValue), Convert.ToInt32(ddRoleList.SelectedValue), cbisActive.Checked, Session["USER_CODE"].ToString());      // add new employee role mapping
                    displayMessage(lblMessage.Text = "Saved Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    displayMessage(lblMessage.Text = "Already Added.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else if (btnSave.Text == "Update")  //if btnSave button text equals to "Update"
            {
                employeeRoleController.updateEmployeeRole(Convert.ToInt32(ddEmployeeList.SelectedValue), Convert.ToInt32(ddRoleList.SelectedValue), cbisActive.Checked, Session["USER_CODE"].ToString());       // update the employee role mapping
                displayMessage(lblMessage.Text = "Updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
            }
            this.dataBindToGrid();          // refresh grid
            lblQuestion.Text = "";          // reset all
            ddRoleList.SelectedValue = "-1";
            ddEmployeeList.SelectedValue = "-1";
            ddEmployeeList.Enabled = true;
            ddRoleList.Enabled = true;
            cbisActive.Checked = false;
            btnSave.Text = "Save";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddEmployeeList.Enabled = true;      // reset data fields
            ddRoleList.Enabled = true;
            ddEmployeeList.SelectedValue = "-1";
            ddRoleList.SelectedValue = "-1";
            lblMessage.Text = "";
            lblQuestion.Text = "";
            btnSave.Text = "Save";
            cbisActive.Checked = false;
        }

        protected void gvEmployeeRole_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);        // selected row number
            int employeeUID = Convert.ToInt32(((HiddenField)gvEmployeeRole.Rows[rowNo].FindControl("employeeUID")).Value.Trim());  // get employeeUID by passing row no, employeeUID - hidden field
            int roleUID = Convert.ToInt32(((HiddenField)gvEmployeeRole.Rows[rowNo].FindControl("roleUID")).Value.Trim());       // get roleUID by passing row no, roleUID - hidden field
            List<EmployeeRole> employeeRoleList = (List<EmployeeRole>)ViewState["EMPLOYEE_ROLE"];           // get employeeRole list by view state
            EmployeeRole employeeRole = employeeRoleList.Find(a => a.employeeUID == employeeUID && a.roleUID == roleUID); // get employeeRole by employeeUID & roleUID 
            hdnEmployeeUID.Value = employeeRole.employeeUID.ToString();     // set values
            hdnRoleUID.Value = employeeRole.roleUID.ToString();
            ddEmployeeList.SelectedValue = employeeRole.employeeUID.ToString();
            ddRoleList.SelectedValue = employeeRole.roleUID.ToString();
            cbisActive.Checked = employeeRole.isActive;

            ddEmployeeList.Enabled = false;
            ddRoleList.Enabled = false;

            btnSave.Text = "Update";
            displayQuestion(lblQuestion.Text = "do you want to update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);

        }

        protected void gvEmployeeRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeRole.PageIndex = e.NewPageIndex;      // set new page index
            this.dataBindToGrid();
        }


        private void displayMessage(string msg, string color)       // message
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void displayQuestion(string msg, string color)      // questions message
        {
            lblQuestion.Text = msg;
            lblQuestion.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void dataBindToddRoleList()     // data bind to ddRoleList drop down
        {
            EmployeeRoleController employeeRoleController = new EmployeeRoleControllerImpl();
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.roleUID = -1;
            role.name = "--Select--";
            roleList.Add(role);
            roleList.AddRange(employeeRoleController.getActiveRoleList());
            ddRoleList.DataSource = roleList;
            ddRoleList.DataTextField = "name";
            ddRoleList.DataValueField = "roleUID";
            ddRoleList.DataBind();
        }

        private void dataBindToddEmployeeList()   // data bind to ddEmployeeList drop down
        {
            EmployeeRoleController employeeRoleController = new EmployeeRoleControllerImpl();
            List<Employee> employeeList = new List<Employee>();
            Employee employee = new Employee();
            employee.employeeUID = -1;
            employee.employeeIDName = "--Select--";
            employeeList.Add(employee);
            employeeList.AddRange(employeeRoleController.getActiveEmployeeList());
            ddEmployeeList.DataSource = employeeList;
            ddEmployeeList.DataTextField = "employeeIDName";
            ddEmployeeList.DataValueField = "employeeUID";
            ddEmployeeList.DataBind();
        }

        private void dataBindToGrid()
        {
            EmployeeRoleController employeeRoleController = new EmployeeRoleControllerImpl();
            ViewState["EMPLOYEE_ROLE"] = employeeRoleController.getAllEmployeeRoles();          // get all Employee Role details
            gvEmployeeRole.DataSource = ViewState["EMPLOYEE_ROLE"];     //bind to grid
            gvEmployeeRole.DataBind();

            if (gvEmployeeRole.Rows.Count > 0)      // if gvEmployeeRole grid row count > 0 show the grid div
            {
                hdnEmployeeRoleGridVisible.Value = "1";
            }
            else
            {
                hdnEmployeeRoleGridVisible.Value = "0";     // else hide the grid div
            }
        }

        protected void ddEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void ddRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
    }
}