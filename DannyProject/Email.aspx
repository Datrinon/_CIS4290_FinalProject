<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Email.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name: <asp:TextBox ID="tbName" runat="server"></asp:TextBox><br />
            Email: <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox><br />
            Subject: <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox><br />
            Message: <asp:TextBox ID="tbMessage" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSend" runat="server" Text="Button" />
            <asp:Label ID="lblReturnMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
