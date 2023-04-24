<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManagement.aspx.cs" Inherits="LibrarySystemWeb.RoleManagement" MasterPageFile="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">Role Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
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
                Role
                Name</td>
            <td>
                :</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtName" runat="server" Width="200px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvID" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                &nbsp;&nbsp;</td>
                        <td class="auto-style14">
                Is Active</td>
            <td>
                :</td>
            <td class="auto-style2">
                <asp:CheckBox ID="cbisActive" runat="server" Checked="false" Height="18px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
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
    <%if (hdnRoleGridVisible.Value == "1"){ %>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Role Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRole" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5"
                    onpageindexchanging="gvRole_PageIndexChanging"
                    onselectedindexchanging="gvRole_SelectedIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="roleUID" runat="server" Value='<%# Bind("roleUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Name">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Enabled ="false"
                                    Checked='<%# Bind("isActive") %>' />
                            </ItemTemplate>
                            <HeaderStyle Font-Size="8pt" />
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                        <ItemStyle Width="40px" />
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
                <asp:HiddenField ID="hdnRoleUID" runat="server" />
                <asp:HiddenField ID="hdnRoleGridVisible" runat="server" />
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
        </style>
</asp:Content>
