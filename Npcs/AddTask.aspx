<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="Npcs.AddTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="AddTask.aspx">
        <div>
            Nome da Tarefa: <input type="text" name="taskname" />
            <br />
            Descrição: <input type="text" name="taskdescription" />
            <br />
            <input type="submit" value="Adicionar Tarefa" />
        </div>    
    </form>

    


</body>
</html>