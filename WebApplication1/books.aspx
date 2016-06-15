<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="WebApplication1.books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .outer{
  margin-top: 30px;
  text-align: center;
}
.outer img{
  display: inline-block;
}

.table{
  text-align: center;
}

div{
  margin-top: 10px;
  margin-bottom: 15px;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="outer">
    <img src="../images/bookprofile.jpg" class="img-circle img-responsive"alt="An image of the book"/>
</div>
<div>
<table align="center"style="width:30%">
  <tr>
    <td><label for="name">Book Name</label></td>
    <td><asp:TextBox ID="txtBook" runat="server" Width="250px" /></td> 
    
  </tr>
  <tr>
    <td><label for="category">Genre</label></td>
    <td><asp:TextBox ID="txtGenre" runat="server" Width="250px" /></td> 
    
  </tr>
  <tr>
    <td><label for="isbn">ISBN</label></td>
    <td><asp:TextBox ID="txtISBN" runat="server" Width="250px" /></td> 
    
  </tr>
    <tr>
    <td><label for="author">Author</label></td>
    <td><asp:TextBox ID="txtAuthor" runat="server" Width="250px" /></td> 
    
  </tr>
  
  
    <tr>
    <td><label for="publisher">Publisher</label></td>
    <td><asp:TextBox ID="txtPublisher" runat="server" Width="250px" /></td> 
    
  </tr>
</tr>
    <tr>
    <td><label for="yearofpublication">Year of Publication</label></td>
    <td><asp:TextBox ID="txtyop" runat="server" Width="250px" /></td> 
    
  </tr>
<tr>
    <td><label for="rating">Average Rating</label></td>
    <td><asp:TextBox ID="txtRating" runat="server" Width="250px" /></td> 
    
  </tr>
<tr>
    <td><label for="quantity">Quantity</label></td>
    <td><asp:TextBox ID="txtQuantity" runat="server" Width="250px" /></td> 
    
  </tr>

</table>
</div>
<div style="text-align:center">
    <asp:Button ID="btnOrder" Text="Order" runat="server" OnClick="btnOrder_Click" />  
    
</div>
<table align="center"style="width:30%">
<tr>
    <td><label for="rating">Provide your Rating</label></td>
    <td><asp:TextBox ID="txtRate" runat="server" Width="250px" /></td> 
    
  </tr>
</table>
 <div style="text-align:center">
    <asp:Button ID="btnRate" Text="Rate" runat="server" OnClick="btnRate_Click" />     
</div>





</asp:Content>
