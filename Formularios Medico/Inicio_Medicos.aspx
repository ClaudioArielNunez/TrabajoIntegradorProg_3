<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio_Medicos.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Medico.Inicio_Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Bienvenido/a,
                dr/a
                <asp:Label ID="lblUsuario" runat="server" /></h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Medico/TurnosAsignados.aspx" Font-Size="Large">Ver turnos asignados</asp:HyperLink>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlUsuario" runat="server" NavigateUrl="~/Formularios Medico/UsuarioPassword_Medico.aspx" Font-Size="Large">Cambiar claves</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
