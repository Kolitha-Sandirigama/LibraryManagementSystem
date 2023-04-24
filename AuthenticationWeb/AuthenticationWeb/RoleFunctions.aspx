<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="RoleFunctions.aspx.cs" Inherits="LibrarySystemWeb.RoleFunctions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumb">Role Function Management</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Role Detail</th>
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
                Role</td>
            <td>
                :</td>
            <td >
                <asp:DropDownList ID="ddRole" runat="server" Height="24px" AutoPostBack="True"
                    Width="250px" OnSelectedIndexChanged="ddRole_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
      </table>
    </div>

    <div class="divGroup">
        <table class="cs1">
        <tr>
            <th colspan="4" style="font-size:small" >
                Function Detail</th>
            <th class="auto-style9">
                &nbsp;</th>
            <th class="auto-style8">
                &nbsp;</th>
            <th class="auto-style6">
                &nbsp;</th>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td>
                <asp:ListBox ID="lbAllFunctions" runat="server" Width="240px"></asp:ListBox>
            </td>
            <td class="auto-style9">
                &nbsp;</td>
            <td >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAdd" runat="server" Height="20px" Text="&gt;&gt;" 
                    Width="50px"  Font-Bold="True" OnClick="btnAdd_Click" />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRemove" runat="server" Height="20px" Text="&lt;&lt;" 
                    Width="50px" Font-Bold="True" OnClick="btnRemove_Click" />
                </td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style8">
                <asp:ListBox ID="lbSelectedFunctions" runat="server" Width="240px"></asp:ListBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                &nbsp;</td>
            <td class="auto-style1">
                </td>
            <td class="auto-style10">
                </td>
            <td class="auto-style3">
                &nbsp;<asp:Button ID="btnSave" runat="server" Height="20px" Text="Save" 
                    Width="75px" ValidationGroup="ValSave" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnReset" runat="server" Height="20px" Text="Reset" 
                    Width="75px" OnClick="btnReset_Click" />
                </td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </div>
    <%if (hdnRoleFunctionGridVisible.Value == "1"){ %>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Role Function Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvRoleFunctions" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" onpageindexchanging="gvRoleFunctions_PageIndexChanging" 
                    PageSize="5" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="roleUID" runat="server" Value='<%# Bind("roleUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="functionUID" runat="server" Value='<%# Bind("functionUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>

                        <asp:BoundField DataField="roleName" HeaderText="Role">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="150px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="functionName" HeaderText="Function">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="350px" />
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
                <asp:HiddenField ID="hdnBSRWorkTypeUID" runat="server" />
                <asp:HiddenField ID="hdnRoleFunctionGridVisible" runat="server" />
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
        .auto-style6 {
            width: 30px;
        }
        .auto-style7 {
            height: 19px;
            width: 30px;
        }
        .auto-style8 {
            width: 245px;
        }
        .auto-style9 {
            width: 14px;
        }
        .auto-style10 {
            height: 19px;
            width: 14px;
        }
    </style>
</asp:Content>
