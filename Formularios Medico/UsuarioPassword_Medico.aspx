<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioPassword_Medico.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Medico.UsuarioPassword_Medico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style4 {
            width: 401px;
        }

        .auto-style6 {
            width: 221px;
        }
        .auto-style7 {
            width: 707px;
        }
        .auto-style8 {
            width: 221px;
            height: 30px;
        }
        .auto-style9 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Usuario:
                        <asp:Label ID="lblUsuario" runat="server" /></td>
                    <td class="auto-style7">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Medico/Inicio_Medicos.aspx" Font-Size="Medium">Volver a inicio</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Button ID="btnCerrarSesion" runat="server" OnClick="btnCerrarSesion_Click" Text="Cerrar sesión" ValidationGroup="grupo2" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h2>Cambiar Usuario y Contraseña</h2>
        </div>
        <p>
            &nbsp;
        </p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">Usuario actual:</td>
                <td>
                    <asp:TextBox ID="txtUsuarioActual" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuarioActual" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Nuevo usuario:</td>
                <td>
                    <asp:TextBox ID="txtNuevoUsuario" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNuevoUsuario" runat="server" ControlToValidate="txtNuevoUsuario" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Contraseña actual:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtContraseñaActual" runat="server" TextMode="Password" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContraAct" runat="server" ControlToValidate="txtContraseñaActual" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style6">Nueva contraseña:</td>
                <td>
                    <asp:TextBox ID="txtNuevaContraseña" runat="server" TextMode="Password" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContraNue" runat="server" ControlToValidate="txtNuevaContraseña" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Confirmar&nbsp; contraseña:</td>
                <td>
                    <asp:TextBox ID="txtConfirmarContraseña" runat="server" TextMode="Password" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:CompareValidator ID="cvConstrasenias" runat="server" ControlToCompare="txtConfirmarContraseña" ControlToValidate="txtNuevaContraseña" ErrorMessage="Las contraseñas deben de ser iguales" ForeColor="Red" ValidationGroup="grupo1"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" OnClick="btnCambiar_Click" ValidationGroup="grupo1" />
                </td>
                <td>
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Black"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
