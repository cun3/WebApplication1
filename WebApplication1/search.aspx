<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication1.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'/>
    <link rel='stylesheet prefetch' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.1/animate.min.css'/>

    <style>
        .button{
              margin:auto;
              display:block;
              }
        .row{
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <label for="title">Title</label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <label for="author">Author</label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </div>
            
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <label for="publisher">Publisher</label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <label for="genre">Genre</label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
                </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label for="isbn">ISBN</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                    </div>                    
                </div>
        <div class="row">
            <div class="col-sm-12 text-center">
                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
            </div>
        </div>
            
</div>
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2"
    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" AllowPaging="true" PageSize="10" OnPageIndexChanging="grid_PageIndexChanging">
    <Columns>
       <asp:BoundField ItemStyle-Width="350px" DataField="ISBN" HeaderText="ISBN" HtmlEncode="False" DataFormatString="<a target='_parent' href='books.aspx?code={0}'>Link to the book</a>" />
         <%--<asp:BoundField ItemStyle-Width="150px" DataField="ISBN" HeaderText="ISBN" />--%>
        <asp:BoundField ItemStyle-Width="350px" DataField="TITLE" HeaderText="Book Title" />
        <asp:BoundField ItemStyle-Width="150px" DataField="BOOK_CATEGORY" HeaderText="Genre" />
        <asp:BoundField ItemStyle-Width="150px" DataField="YEAR_OF_PUBLICATION" HeaderText="Year of Publication" />
        <asp:BoundField ItemStyle-Width="200px" DataField="AUTHOR_NAME" HeaderText="Author" />  
        <asp:BoundField ItemStyle-Width="250px" DataField="PUBLICATION_HOUSE_NAME" HeaderText="Publication House" />  
    </Columns>
</asp:GridView>
    </div>

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
</asp:Content>
