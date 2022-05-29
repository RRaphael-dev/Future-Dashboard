<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Login</title>
    <meta name="description" content="Login - Register Template"/>
    <meta name="author" content="Lorenzo Angelino aka MrLolok"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
    <link rel="stylesheet" href="~/login/css/main.css"/>
    <style>
        body {
            background-color: #303641;
        }
    </style>
</head>
<body>
    <div id="container-login">
        <div id="title">
            <i class="material-icons lock">lock</i> Inloggen
        </div>
        <div class="register">
            <form id="form1" runat="server">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/login/RBfcoBt.png" Width="300" />
            </form>
        </div>
    </div>
</body>
</html>
