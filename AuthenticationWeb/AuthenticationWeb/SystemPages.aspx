<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="SystemPages.aspx.cs" Inherits="LibrarySystemWeb.SystemPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">System Pages Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Page Details</th>
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
                Page Name</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtPageName" runat="server" Height="18px" 
                    Width="200px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPageName" runat="server" 
                    ControlToValidate="txtPageName" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                URL</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtURL" runat="server" Height="18px" 
                    Width="200px" MaxLength="400"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvURL" runat="server" 
                    ControlToValidate="txtURL" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="72px"
                    Width="200px" MaxLength="290" TextMode="MultiLine"></asp:TextBox>
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
                    Width="75px" ValidationGroup="ValSave" OnClick="btnSave_Click" />
&nbsp;
                <asp:Button ID="btnReset" runat="server" Height="20px" Text="Reset" 
                    Width="75px" OnClick="btnReset_Click" />
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
    
    <%if (hdnsystemPagesGridVisible.Value == "1"){ %>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Page Detail Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvSystemPages" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5" onpageindexchanging="gvSystemPages_PageIndexChanging" >
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="systemPageUID" runat="server" Value='<%# Bind("systemPageUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                        <asp:BoundField HeaderText="Name" DataField="systemPageName">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100" />
                        </asp:BoundField>
                        <asp:BoundField DataField="systemPageURL" HeaderText="URL">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="400" />
                        </asp:BoundField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="200px" />
                        </asp:BoundField>                        
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
                <asp:HiddenField ID="hdnsystemPagesGridVisible" runat="server" />
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
