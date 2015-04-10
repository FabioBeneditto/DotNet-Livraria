<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LivrariaWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="mensagem" runat="server"></div>

        <asp:Label ID="lblNome" Text="Nome: " runat="server"></asp:Label>
        <asp:TextBox ID="txtNome" CssClass="input-form" runat="server"></asp:TextBox>

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
    </div>
    </form>
</body>
</html>
