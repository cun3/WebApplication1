<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="compareauthors.aspx.cs" Inherits="WebApplication1.compareauthors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
                <table align="center" style="width: 30%; height: 164px;">
                    <tr>
                        <td>
                            <label for="author1">Author 1</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthor1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        
                        <td>
                            <label for="author2">Author 2</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthor2" runat="server" Width="170px" /></td>

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
                            <label for="author">Author</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthorName1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="author">Author</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthorName2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="noofbook">Number of Books written</label></td>
                        <td>
                            <asp:TextBox ID="txtbookNo1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="noofbook">Number of Books written</label></td>
                        <td>
                            <asp:TextBox ID="txtbookNo2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="avg">Average Book Ratings</label></td>
                        <td>
                            <asp:TextBox ID="txtrating1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="avg">Average Book Ratings</label></td>
                        <td>
                            <asp:TextBox ID="txtrating2" runat="server" Width="170px" /></td>
                        </tr>

                    
                    
                </table>
            </div>
</asp:Content>
