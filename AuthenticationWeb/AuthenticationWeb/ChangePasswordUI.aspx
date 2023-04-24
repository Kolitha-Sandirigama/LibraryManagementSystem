<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ChangePasswordUI.aspx.cs" Inherits="LibrarySystemWeb.ChangePasswordUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">Change Password</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Password Details</th>
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
                Old Password</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" Height="18px" 
                    Width="150px" MaxLength="50" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" 
                    ControlToValidate="txtOldPassword" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                New Password</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" Height="18px" 
                    Width="150px" MaxLength="100" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" 
                    ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                Re-enter New Password</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtReEnterNewPassword" runat="server" Height="18px" Width="150px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReEnterNewPassword" runat="server" 
                    ControlToValidate="txtReEnterNewPassword" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
