<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--Renglon del titulo--%>
        <div style="height:80px; width:100%; text-align:center">
            <h2>Acceso al sistema:</h2>
        </div>
        <%--Renglon del campo Usuario--%>
        <div style="height:50px; width:48%; padding-right:2%; text-align:right; float:left">
            Usuario:
        </div>
        <div style="height:50px; width:50%; float:left">
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>

        <%--Renglon del campo Contraseña--%>
        <div style="height:50px; width:48%; padding-right:2%; text-align:right; float:left">
            Contraseña:
        </div>
        <div style="height:50px; width:50%; float:left">
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <%--Renglon del radiobutton--%>
        <div style="height:30px; width:100%; float:left; text-align:center">
            Tipo de cuenta:
        </div>
        <div style="height:60px; width:45%; float:left"></div>
        <div style="height:60px; width:55%; float:left">
            <asp:RadioButtonList ID="rblTipoDeCuenta" runat="server">
                <asp:ListItem Selected="True">Medico</asp:ListItem>
                <asp:ListItem>Administrador</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <%--Renglon del boton--%>
        <div style="width:100%; text-align:center">
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesion" OnClick="btnLogin_Click"/>
            <br />
            <br />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p class="auto-style1">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <p class="auto-style1">
            <asp:Label ID="lblError2" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
