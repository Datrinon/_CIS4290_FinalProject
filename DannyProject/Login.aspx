<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout.Master" CodeBehind="Login.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-- Required meta tags -->
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
      <!-- Favicon -->
      <link rel="shortcut icon" href="images/favicon.ico" />
      <!-- bootstrap -->
      <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
      <!-- REVOLUTION STYLE SHEETS -->
      <link href="revolution/css/settings.css" rel="stylesheet" type="text/css">
      <!-- main style -->
      <link href="css/style.css" rel="stylesheet" type="text/css" />
      <!-- responsive -->
      <link href="css/responsive.css" rel="stylesheet" type="text/css" />
      <!-- custom -->
      <link href="css/custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>Login</title>
    <div class="shopping-body">
    <h2>Login to your Account</h2>
    <p>Email:<br /></p>
    <asp:TextBox ID="tbEmail" width="200" runat="server"></asp:TextBox><br />
    <p>Password:<br /></p>
    <asp:TextBox ID="tbPassword" TextMode ="Password" Width="200" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" /><br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
