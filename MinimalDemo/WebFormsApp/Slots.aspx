<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Slots.aspx.cs" Inherits="WebFormsApp.Slots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="Button2_Click"></asp:TextBox>   
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
