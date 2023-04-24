<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowingBooks.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="AuthenticationWeb.TransactionWeb.BorrowingBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="breadcrumb">Borrowing Books</div>

    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                Book Details</th>
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
                <asp:DropDownList ID="ddUserID" runat="server" Height="24px" AutoPostBack="True"
                    Width="150px"  >
                </asp:DropDownList>
            </td>

            <td>
                Book</td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="ddBook" runat="server" Height="24px" AutoPostBack="True"
                    Width="150px"  >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Return Date</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtReturnDate" runat="server" Height="18px" 
                    Width="150px" MaxLength="100"></asp:TextBox>
            </td>

            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>

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
    
    <%if(hdnBorrowingBookGridVisible.Value =="1") {%>
    <div class="divGroup">
    <table class="cs1">
        <tr>
            <th colspan="3" style="font-size:small">
                &nbsp;Summary</th>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvBorrowingBooks" runat="server" 
                    AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    PageSize="5"
                    OnPageIndexChanging ="gvBorrowingBooks_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="bookBorrowingRecordUID" runat="server" Value='<%# Bind("bookBorrowingRecordUID") %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                        <asp:BoundField HeaderText="User ID" DataField="userName">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BookName" HeaderText="Book">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ISBNNo" HeaderText="ISBN No">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReturnDate" HeaderText="Deu Date">
                        <HeaderStyle Font-Size="8pt" />
                        <ItemStyle Width="100px" />
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
                <asp:HiddenField ID="hdnBorrowingBookGridVisible" runat="server" />
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
