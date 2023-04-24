<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibraryUserManagement.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="AuthenticationWeb.MasterDataWeb.LibraryUserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="breadcrumb">User Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                User Details</th>
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
                User ID</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server" Height="18px" 
                    Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserID" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

            <td>
                Category</td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="ddUserCategoryList" runat="server" Height="24px" AutoPostBack="True"
                    Width="150px"  >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                First Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtUserFirstName" runat="server" Height="18px" 
                    Width="150px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtUserFirstName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

            <td>
                Last Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtUserLastName" runat="server" Height="18px" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserLastName" runat="server" 
                    ControlToValidate="txtUserLastName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                NIC</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtUserNIC" runat="server" Height="18px" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserNIC" runat="server" 
                    ControlToValidate="txtUserNIC" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
            <td>
                Is Active</td>
            <td>
                :</td>
            <td>
                <asp:CheckBox ID="cbxUserActivate" runat="server" Checked="false" />
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
    
    <%if(hdnUserGridVisible.Value =="1") {%>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                User Detail Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvUser" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5" onselectedindexchanging="gvUser_SelectedIndexChanging"
                    OnPageIndexChanging ="gvUser_OnPageIndexChanging">
                    <Columns>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="userUID" runat="server" Value='<%# Bind("userUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                        <asp:BoundField HeaderText="User ID" DataField="userID">
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
                <asp:HiddenField ID="hdnUserUID" runat="server" />
                <asp:HiddenField ID="hdnUserGridVisible" runat="server" />
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


