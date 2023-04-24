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
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;      // disable the use of unobtrusive JavaScript for client - side validation
            if (!Page.IsPostBack)
            {
                this.dataBindToEmployeeGrid();          // dat bind to grid
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeController employeeController = new EmployeeControllerImpl();
            if (btnSave.Text == "Save")         // if btnSave text equals "Save"
            {
                if (employeeController.findByUserLoginID(txtUserName.Text.Trim()) == null)  // check username already exists by username
                {
                    if (employeeController.findByEmployeeNIC(txtNIC.Text.Trim()) == null)   // check employee already exists by NIC
                    {
                        employeeController.addEmployee(txtEmployeeID.Text.Trim(), txtEmployeeFirstName.Text.Trim(), txtEmployeeLastName.Text.Trim(), txtNIC.Text.Trim(), Session["USER_CODE"].ToString());  // add a record to employee table
                        int emploeeUID = employeeController.getEmploeeUIDByAll(txtEmployeeID.Text.Trim(), txtEmployeeFirstName.Text.Trim(), txtEmployeeLastName.Text.Trim(), txtNIC.Text.Trim());       // get employeeUID
                        employeeController.addUserLogin(txtUserName.Text.Trim(), cbxActivate.Checked, emploeeUID, Session["USER_CODE"].ToString());     // add a record to userlogin table

                        clearData();                    // clear data fields
                        this.dataBindToEmployeeGrid();      // reload grid
                        DisplayMessage(lblMessage.Text = "Added Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                    }
                    else
                    {
                        DisplayMessage(lblMessage.Text = "User Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                    }
                }
                else
                {
                    DisplayMessage(lblMessage.Text = "UserName Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
            }
            else if (btnSave.Text == "Update")
            {     // if btnSave text equals "Update"
                if (employeeController.findByEmployeeNICAndEmpUID(Int32.Parse(hdnEmployeeUID.Value), txtNIC.Text.ToString().Trim()) == null)    // find employee already exists by NIC and EmployeeUID
                {
                    employeeController.editEmployee(Int32.Parse(hdnEmployeeUID.Value), txtEmployeeID.Text.Trim(), txtEmployeeFirstName.Text.Trim(), txtEmployeeLastName.Text.Trim(), txtNIC.Text.Trim(), Session["USER_CODE"].ToString(), cbxActivate.Checked);      // update employee
                    clearData();                        // clear data fields
                    this.dataBindToEmployeeGrid();      // reload grid
                    DisplayMessage(lblMessage.Text = "Updated Successfully.", AuthenticationWeb.AuthenticationWebRes.SUCCESS_COLOUR);
                }
                else
                {
                    DisplayMessage(lblMessage.Text = "Already Exists.", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
                }
                clearData();        // clear data fields
                btnSave.Text = "Save";  // reset btnSave button text 
                txtUserName.Enabled = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnSave.Text = "Save";
            this.clearData();
        }

        protected void dataBindToEmployeeGrid()
        {                                   // data bind to employee grid
            EmployeeController employeeController = new EmployeeControllerImpl();
            ViewState["Employee_List"] = employeeController.findByAll();                // get all employee data         
            gvEmployee.DataSource = ViewState["Employee_List"];
            gvEmployee.DataBind();

            if (gvEmployee.Rows.Count > 0)      // if gvEmployee grid row count > 0 then show grid div 
            {
                hdnEmployeeGridVisible.Value = "1";
            }
            else
            {
                hdnEmployeeGridVisible.Value = "0";     // else hide grid div

            }
        }

        private void DisplayMessage(string msg, string color)       // message
        {
            lblMessage.Text = msg;
            lblMessage.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void DisplayQuestion(string msg, string color)      // question
        {
            lblQuestion.Text = msg;
            lblQuestion.Style.Add(HtmlTextWriterStyle.Color, color);
        }

        private void clearData()
        {              // reset all
            txtEmployeeID.Text = "";
            txtEmployeeFirstName.Text = "";
            txtEmployeeLastName.Text = "";
            txtNIC.Text = "";
            txtUserName.Text = "";
            lblQuestion.Text = "";
            cbxActivate.Checked = false;
            txtUserName.Enabled = true;
        }

        protected void gvEmployee_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblQuestion.Text = "";
            lblMessage.Text = "";
            int rowNo = Convert.ToInt32(e.NewSelectedIndex);        // get selected row no
            int employeeUID = Convert.ToInt32(((HiddenField)gvEmployee.Rows[rowNo].FindControl("employeeUID")).Value.Trim());  // get employee uid  by passing rowuid, employeeUID- hiddenfield
            List<Employee> employeeList = (List<Employee>)ViewState["Employee_List"];       // get all employeelist by using ViewState
            Employee employee = employeeList.Find(a => a.employeeUID == employeeUID);       // find employee by employeeUID
            hdnEmployeeUID.Value = employee.employeeUID.ToString();     // set data
            txtEmployeeID.Text = employee.employeeID.ToString();
            txtEmployeeFirstName.Text = employee.firstName.ToString();
            txtEmployeeLastName.Text = employee.lastName.ToString();
            txtUserName.Text = gvEmployee.Rows[rowNo].Cells[4].Text;
            txtUserName.Enabled = false;
            txtNIC.Text = employee.NIC.ToString();
            cbxActivate.Checked = employee.isActive;

            btnSave.Text = "Update";
            btnReset.Text = "Cancel";
            DisplayQuestion(lblQuestion.Text = "Do you want to Update?", AuthenticationWeb.AuthenticationWebRes.ERROR_COLOUR);
        }

        protected void gvEmployee_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;          // set new page number
            this.dataBindToEmployeeGrid();
        }
    }
}