<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="EmployeeManagement.aspx.cs" Inherits="LibrarySystemWeb.EmployeeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="breadcrumb">Employee Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Employee Details</th>
        </tr>
        <tr>
            <td style="width:150px">
                &nbsp;</td>
            <td style="width:6px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Employee ID</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtEmployeeID" runat="server" Height="18px" 
                    Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmployeeID" runat="server" 
                    ControlToValidate="txtEmployeeID" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

            <td>
                User Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Height="18px" Width="150px" MaxLength="9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                First Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtEmployeeFirstName" runat="server" Height="18px" 
                    Width="150px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtEmployeeFirstName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

            <td>
                Last Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtEmployeeLastName" runat="server" Height="18px" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtEmployeeLastName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                NIC</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtNIC" runat="server" Height="18px" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNIC" runat="server" 
                    ControlToValidate="txtNIC" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
            <td>
                Is Active</td>
            <td>
                :</td>
            <td>
                <asp:CheckBox ID="cbxActivate" runat="server" Checked="false" />
            </td>
        </tr>



        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblQuestion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                </td>
            <td class="auto-style1">
                </td>
            <td class="auto-style1">
                <asp:Button ID="btnSave" runat="server" Height="20px" Text="Save" 
                    Width="75px" onclick="btnSave_Click" ValidationGroup="ValSave" />
&nbsp;
                <asp:Button ID="btnReset" runat="server" Height="20px" Text="Reset" 
                    Width="75px" onclick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </div>
    
    <%if(hdnEmployeeGridVisible.Value =="1") {%>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Employee Detail Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvEmployee" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5" onselectedindexchanging="gvEmployee_SelectedIndexChanging"
                    OnPageIndexChanging ="gvEmployee_OnPageIndexChanging">
                    <Columns>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="employeeUID" runat="server" Value='<%# Bind("employeeUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                        <asp:BoundField HeaderText="Employee ID" DataField="employeeID">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100" />
                        </asp:BoundField>
                        <asp:BoundField DataField="firstName" HeaderText="First Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="lastName" HeaderText="Last Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userLogin.UserName" HeaderText="User Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NIC" HeaderText="NIC">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="IsActive">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Enabled ="false"
                                    Checked='<%# Bind("isActive") %>' />
                            </ItemTemplate>
                            <HeaderStyle Font-Size="8pt" />
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                        <ItemStyle Width="50px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnEmployeeUID" runat="server" />
                <asp:HiddenField ID="hdnEmployeeGridVisible" runat="server" />
            </td>
        </tr>
        </table>
    </div>
    <%} %>
    <div class="divGroupEx">
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
    </style>
</asp:Content>

