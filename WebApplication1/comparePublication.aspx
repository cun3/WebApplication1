<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="comparePublication.aspx.cs" Inherits="WebApplication1.comparePublication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                <table align="center" style="width: 30%; height: 164px;">
                    <tr>
                        <td>
                            <label for="publisher1">Publisher 1</label></td>
                        <td>
                            <asp:TextBox ID="txtPublisher1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        
                        <td>
                            <label for="publisher2">Publisher 2</label></td>
                        <td>
                            <asp:TextBox ID="txtPublisher2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td></td>
                        <td>
                            </td>

                    </tr>
                    <tr>
                        <td>
                           </td> 
                        <td>
                            </td>
                        <td>
                           <asp:Button ID="btnCompare" Text="Compare" runat="server" OnClick="btnCompare_Click" /></td>
                        
                        <td>
                            </td>
                        <td>
                            </td>

                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td></td>
                        <td>
                            </td>

                    </tr>
                    </table>
        </div>
    <div runat="server" id="divResults" >
        <table align="center" style="width: 30%; height: 164px;">
                    <tr>
                        <td>
                            <label for="publisher">Publisher</label></td>
                        <td>
                            <asp:TextBox ID="txtpublisherName1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="publisher">Publisher</label></td>
                        <td>
                            <asp:TextBox ID="txtpublisherName2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="noofbook">Number of Books published</label></td>
                        <td>
                            <asp:TextBox ID="txtbookNo1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="noofbook">Number of Books published</label></td>
                        <td>
                            <asp:TextBox ID="txtbookNo2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="total">Total Books Sold</label></td>
                        <td>
                            <asp:TextBox ID="txttotal1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="total">Total Books Sold</label></td>
                        <td>
                            <asp:TextBox ID="txttotal2" runat="server" Width="170px" /></td>
                        </tr>

                    
                    
                </table>
            </div>
</asp:Content>
