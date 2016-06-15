<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="compareBooks.aspx.cs" Inherits="WebApplication1.compareBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                <table align="center" style="width: 30%; height: 164px;">
                    <tr>
                        <td>
                            <label for="book1">Book 1</label></td>
                        <td>
                            <asp:TextBox ID="txtBook1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        
                        <td>
                            <label for="book2">Book 2</label></td>
                        <td>
                            <asp:TextBox ID="txtBook2" runat="server" Width="170px" /></td>

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
                            <label for="isbn">Title</label></td>
                        <td>
                            <asp:TextBox ID="txtTitle1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="isbn">Title</label></td>
                        <td>
                            <asp:TextBox ID="txtTitle2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="author">Author</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthor1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="author">Author</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthor2" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td>
                            <label for="yop">Year of Publication</label></td>
                        <td>
                            <asp:TextBox ID="txtyop1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="yop">Year of Publication</label></td>
                        <td>
                            <asp:TextBox ID="txtyop2" runat="server" Width="170px" /></td>
                        </tr>

                    <tr>
                        <td>
                            <label for="pub">Publisher</label></td>
                        <td>
                            <asp:TextBox ID="txtPublisher1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="pub">Publisher</label></td>
                        <td>
                            <asp:TextBox ID="txtPublisher2" runat="server" Width="170px" /></td>
                        </tr>
                    <tr>
                        <td>
                            <label for="rating">Average Rating</label></td>
                        <td>
                            <asp:TextBox ID="txtrate1" runat="server" Width="170px" /></td>
                        <td>
                            <label for="book1"></label></td>
                        <td>
                            <label for="rating">Average Rating</label></td>
                        <td>
                            <asp:TextBox ID="txtrate2" runat="server" Width="170px" /></td>
                        </tr>


                    
                </table>
            </div>
</asp:Content>
