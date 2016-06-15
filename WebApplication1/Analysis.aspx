<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Analysis.aspx.cs" Inherits="WebApplication1.Analysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #inner {
    width: 50%;
    margin: 0 auto; 
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" style="width: 30%; height: 164px;">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlOptions"
                                runat="server" Style="margin-left: 0px" Width="175px">
                                <%--<asp:ListItem>Admin</asp:ListItem>--%>
                                <asp:ListItem Value="0">Books Published</asp:ListItem>
                                <asp:ListItem Value="1">Books Sold</asp:ListItem>
                                <asp:ListItem Value="2">Orders Placed</asp:ListItem>
                            </asp:DropDownList>
                </td>
                </tr>
            <tr>
                <td class="auto-style2">
                            <label for="userId">From Year</label></td>
                        <td>
                            <asp:TextBox ID="txtYear" runat="server" Width="170px" /></td>
                <td></td>
                <td class="auto-style2">
                            <label for="userId">To Year</label></td>
                        <td>
                            <asp:TextBox ID="txtToYear" runat="server" Width="170px" /></td>

            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" /></td>
                <td></td>
                <td></td>
            </tr>
            
            </table>
        </div>
    
    <div id="divResults" runat="server">
    <table>
        <td></td>
        <td>
    <asp:Chart ID="Chart1" runat="server" Width="1265px">
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</td>
        <td></td>
    </table>
</div>
    
</asp:Content>
