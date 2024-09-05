<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Npcs.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="AddUser.aspx">
    <div>
        Username: <input type="text" name="username" />
        <br />
        Password: <input type="text" name="password" />
        <br />
        Email: <input  type="text" name="emailadress"/>
        <input type="submit" value="Add User" />
    </div>
</form>
</body>
</html>