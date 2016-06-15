<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="publisher.aspx.cs" Inherits="WebApplication1.publisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
     
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xs-offset-0 col-sm-offset-0 col-md-offset-3 col-lg-offset-3 toppad" >
   
   
          <div class="panel panel-info">
            <div class="panel-heading">
              <h3 class="panel-title" hidden="hidden"></h3>
            </div>
            <div class="panel-body">
              <div class="row">
                <div class="col-md-3 col-lg-3 " align="center"> <img alt="User Pic" src="http://babyinfoforyou.com/wp-content/uploads/2014/10/avatar-300x300.png" class="img-circle img-responsive"> </div>
                
                <div class=" col-md-9 col-lg-9 "> 
                  <table class="table table-user-information">
                    <tbody>
                      <tr>
                        <td>Publisher ID:</td>
                        <td>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPublisherId" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>Publication Name:</td>
                        <td>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPubName" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td></td>
                          <td><asp:Button ID="btnAnalysis" Text="Analysis" runat="server" OnClick="btnAnalysis_Click" /></td>
                        </tr>
                    </tbody>
                  </table>
                  
                 
                </div>
              </div>
            </div>
                 
          </div>
        </div>
      </div>
    </div>
</asp:Content>
