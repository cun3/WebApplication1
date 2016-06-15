<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication1.profile" %>
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
                        <td>User ID:</td>
                        <td>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>Location:</td>
                        <td>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>Age:</td>
                        <td>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
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
