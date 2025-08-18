<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EB_Prj.Login" %>
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login</h2>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />
    <asp:TextBox ID="txtUser" runat="server" Placeholder="Username"></asp:TextBox><br />
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
</asp:Content>
