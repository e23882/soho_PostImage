<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ViewImage._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="WebApi/Get"></asp:Label>
            <br />
            <asp:TextBox ID="tbUrl" runat="server" Width="343px">http://localhost:2622/Api/Image/CommonSearch</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="顯示圖片"  OnClick="Button1_Click"/>
            <br />
            <br />
            <asp:Label ID="lbImg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
