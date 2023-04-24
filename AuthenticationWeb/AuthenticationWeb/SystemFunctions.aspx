<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="SystemFunctions.aspx.cs" Inherits="LibrarySystemWeb.SystemFunctions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">System Functions</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                System Functions Detail</th>
        </tr>
        <tr>
            <td style="width:150px">
                &nbsp;</td>
            <td style="width:6px">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                Description</td>
            <td>
                :</td>
            <td >
                <asp:TextBox ID="txtDescription" runat="server" Height="18px"
                    Width="190px" MaxLength="225"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValSave"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                Is Active</td>
            <td class="auto-style5">
                :</td>
            <td>
                <asp:CheckBox ID="cbIsActivate" runat="server" Checked="false" />
            </td>
        </tr>
        <tr>
            <td>
                Notes</td>
            <td>
                :

            </td>
            <td >
                <asp:TextBox ID="txtNotes" runat="server" Height="72px"
                    Width="190px" MaxLength="290" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="lblQuestion" runat="server"></asp:Label>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </div>
    
    <%if(hdnSystemFunctionGridVisible.Value == "1"){ %>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                System Functions Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvSystemFunctions" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" onpageindexchanging="gvSystemFunctions_PageIndexChanging" 
                    PageSize="5"   onselectedindexchanging="gvSystemFunctions_SelectedIndexChanging" >
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="SystemFunctionUID" runat="server" Value='<%# Bind("systemFunctionUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>

                        <asp:BoundField DataField="description" HeaderText="Description">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="350px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="notes" HeaderText="Notes">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="350px" />
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
                <asp:HiddenField ID="hdnSystemFunctionUID" runat="server" />
                <asp:HiddenField ID="hdnSystemFunctionGridVisible" runat="server" />
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
            width: 262px;
        }
        .auto-style3 {
            height: 19px;
            width: 262px;
        }
        .auto-style4 {
            width: 47px;
        }
        .auto-style5 {
            width: 1px;
        }
    </style>
</asp:Content>
