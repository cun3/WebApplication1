<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            width: 148px;
        }
    </style>
</head>


<body>
    <form id="form1" runat="server">
        <div class="container" align="right">

            <div class="box-header">
                <h2 align="left" style="width: 30%">&nbsp;&nbsp;&nbsp; Login </h2>
            </div>
            <div>
                <table align="right" style="width: 30%; height: 164px;">
                    <tr>
                        <td class="auto-style2">
                            <label for="userId">User Id</label></td>
                        <td>
                            <asp:TextBox ID="txtUserId" runat="server" Width="170px" /></td>

                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <label for="role">Role</label></td>
                        <td>
                            <asp:DropDownList ID="ddlRole"
                                runat="server" Style="margin-left: 0px" Width="175px">
                                <%--<asp:ListItem>Admin</asp:ListItem>--%>
                                <asp:ListItem>Member</asp:ListItem>
                                <asp:ListItem>Publisher</asp:ListItem>
                            </asp:DropDownList></td>

                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <label for="pwd">Password</label></td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="password" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" /></td>


                    </tr>
                </table>
            </div>

        </div>

        
    </form>
</body>
</html>
