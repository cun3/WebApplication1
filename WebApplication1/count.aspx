<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="count.aspx.cs" Inherits="WebApplication1.count" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <table align="center" style="width: 30%; height: 164px;">
                    <tr>
                        <td>
                            <label for="book">Book Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtBook" runat="server" Width="170px" /></td>                        

                    </tr>
                    <tr>
                        <td>
                            <label for="user">User Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtUser" runat="server" Width="170px" /></td>
                        

                    </tr>
               
                <tr>
                        <td>
                            <label for="author">Author Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtAuthor" runat="server" Width="170px" /></td>
                        

                    </tr>
                 <tr>
                        <td>
                            <label for="publisher">Publisher Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtPublisher" runat="server" Width="170px" /></td>
                        

                    </tr>

                 <tr>
                        <td>
                            <label for="rating">Rating Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtRating" runat="server" Width="170px" /></td>
                        

                    </tr>
                 <tr>
                        <td>
                            <label for="order">Order Table Count</label></td>
                        <td>
                            <asp:TextBox ID="txtOrder" runat="server" Width="170px" /></td>
                        

                    </tr>
                 <tr>
                        <td>
                            
                        <td>
                            <asp:Button ID="btnCount" Text="Count!!" runat="server" OnClick="btnCount_Click" /></td>
                        

                    </tr>
                    
                </table>
    
    </div>
</asp:Content>
