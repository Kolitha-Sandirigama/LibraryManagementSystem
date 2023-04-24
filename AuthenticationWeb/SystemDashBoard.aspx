<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemDashBoard.aspx.cs" Inherits="LibrarySystemWeb.SystemDashBoard"  MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Dash_Board.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="Main_Table">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3"><strong>WELCOME</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" >
                <table class="Part1">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Total Estimates</td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblTotalEstimate" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            
            <td>&nbsp;</td>
           


            <td class="auto-style1" >
                <table class="Part1">
                 <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Total Bills</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTotalBill" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >
                <table class="Part1">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Inprogress Estimates</td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblInprogessEstimate" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            
            <td>&nbsp;</td>
           


            <td class="auto-style1" >
                <table class="Part1">
                 <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Inprogress Bills</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInprogressBills" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
            
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <div class="divGroupEx">
    </div>

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <style type="text/css">
        .auto-style1 {
            width: 401px;
        }
    </style>
</asp:Content>

