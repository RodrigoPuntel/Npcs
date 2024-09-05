<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApiLogin.aspx.cs" Inherits="Npcs.ApiLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="ApiLogin.aspx">
    <div>
        Usuário: <input type="text" name="username" />
        <br />
        Senha: <input type="text" name="password" />
        <br />        
        <input type="submit" value="Login" />
    </div>
    </form>
</body>
</html>
