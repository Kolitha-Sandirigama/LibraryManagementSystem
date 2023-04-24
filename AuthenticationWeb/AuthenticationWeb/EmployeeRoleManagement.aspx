<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRoleManagement.aspx.cs"  MasterPageFile="~/MasterPage.Master" Inherits="LibrarySystemWeb.EmployeeRoleManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">Employee Role Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Employee -
                Role Details</th>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style14">
                Employee</td>
            <td>
                :</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddEmployeeList" runat="server" Height="24px" AutoPostBack="True"
                    Width="250px" OnSelectedIndexChanged="ddEmployeeList_SelectedIndexChanged"  >
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                &nbsp;&nbsp;</td>
                        <td class="auto-style14">
                            Role</td>
            <td>
                :</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddRoleList" runat="server" Height="24px"
                    Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddRoleList_SelectedIndexChanged"  >
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style14">
                Is Active</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                <asp:CheckBox ID="cbisActive" runat="server" Checked="false" Height="18px" />
            </td>
            <td class="auto-style4">
                &nbsp;</td>
                        <td class="auto-style14">
                            &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style15">
                </td>
            <td class="auto-style1">
                </td>
            <td class="auto-style3">
                <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                </td>
            <td class="auto-style1">
                </td>
            <td class="auto-style3">
                <asp:Button ID="btnSave" runat="server" Height="20px" Text="Save" 
                    Width="75px" ValidationGroup="ValSave" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnReset" runat="server" Height="20px" Text="Reset" 
                    Width="75px" OnClick="btnReset_Click" />
                </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        </table>
        </div>
    <%if (hdnEmployeeRoleGridVisible.Value == "1") {%>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Employee - Role Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvEmployeeRole" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5"
                    onpageindexchanging="gvEmployeeRole_PageIndexChanging"
                    onselectedindexchanging="gvEmployeeRole_SelectedIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="employeeUID" runat="server" Value='<%# Bind("employeeUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="roleUID" runat="server" Value='<%# Bind("roleUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>

                        <asp:BoundField DataField="roleName" HeaderText="Role">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="employeeID" HeaderText="Employee ID">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="firstName" HeaderText="First Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="lastName" HeaderText="Last Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled ="false"
                                    Checked='<%# Bind("IsActive") %>' />
                            </ItemTemplate>
                            <HeaderStyle Font-Size="8pt" />
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                        <ItemStyle Width="50px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style1">
                </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnEmployeeRoleUID" runat="server" />
                <asp:HiddenField ID="hdnEmployeeUID" runat="server" />
                <asp:HiddenField ID="hdnRoleUID" runat="server" />
                <asp:HiddenField ID="hdnEmployeeRoleGridVisible" runat="server" />
            </td>

        </tr>
        </table>
    </div>
    <% }%>
    <div class="divGroupEx">
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            width: 254px;
        }
        .auto-style3 {
            height: 19px;
            width: 254px;
        }
        .auto-style4 {
            width: 16px;
        }
        .auto-style6 {
            width: 101px;
            height: 15px;
        }
        .auto-style7 {
            width: 6px;
            height: 15px;
        }
        .auto-style8 {
            width: 254px;
            height: 15px;
        }
        .auto-style14 {
            width: 101px;
        }
        .auto-style15 {
            width: 101px;
            height: 19px;
        }
        </style>
</asp:Content>
