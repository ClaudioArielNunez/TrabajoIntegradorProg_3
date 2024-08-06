<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_medicos.AgregarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Medicos - Agregar</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style4 {
            width: 355px;
            height: 37px;
        }

        .auto-style5 {
            width: 69px;
            height: 37px;
        }

        .auto-style6 {
            width: 100%;
            margin-top: 21px;
        }

        .auto-style8 {
            width: 245px;
        }

        .auto-style11 {
            width: 144px;
            text-align: right;
        }

        .auto-style12 {
            width: 80px;
            height: 30px;
        }

        .auto-style18 {
            width: 190px;
            height: 30px;
            text-align: right;
        }

        .auto-style19 {
            width: 190px;
            text-align: right;
        }

        .auto-style22 {
            width: 316px;
        }

        .auto-style23 {
            width: 300px;
            height: 30px;
        }

        .auto-style24 {
            width: 300px;
        }

        .auto-style25 {
            width: 144px;
            height: 30px;
            text-align: right;
        }

        .auto-style28 {
            height: 37px;
        }

        .auto-style29 {
            width: 90px;
            height: 30px;
            text-align: right;
        }

        .auto-style31 {
            width: 90px;
        }

        .auto-style32 {
            width: 80px;
        }

        .auto-style33 {
            width: 90px;
            height: 30px;
        }
        .auto-style34 {
            width: 80px;
            height: 58px;
        }
        .auto-style35 {
            width: 144px;
            text-align: right;
            height: 58px;
        }
        .auto-style36 {
            width: 300px;
            height: 58px;
        }
        .auto-style37 {
            width: 190px;
            text-align: right;
            height: 58px;
        }
        .auto-style38 {
            width: 90px;
            height: 58px;
        }
        .auto-style39 {
            width: 80px;
            height: 28px;
        }
        .auto-style40 {
            width: 144px;
            height: 28px;
            text-align: right;
        }
        .auto-style41 {
            width: 300px;
            height: 28px;
        }
        .auto-style42 {
            width: 190px;
            height: 28px;
            text-align: right;
        }
        .auto-style43 {
            width: 90px;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style8">Usuario:
                    <asp:Label ID="lblUsuarioAdmin" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/AgregarPaciente.aspx">Pacientes</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;
                    <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/Formularios Admin/AsignacionDeTurnos.aspx">Turnos</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/Informes.aspx">Informes</asp:HyperLink>
                    </td>
                    <td>Opciones de Medico:
                        <asp:HyperLink ID="hlAgregarMedico" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/EliminarMedico.aspx">Editar/Eliminar Medico</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" ValidationGroup="grupo2" />
                    </td>
                    <td class="auto-style22">&nbsp;</td>
                    <td>&nbsp;<asp:HyperLink ID="hlAgregarMedico0" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/ListarMedicos.aspx">Listar Medicos</asp:HyperLink>
                    </td>
                </tr>
            </table>

            <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Agregar Médico</h1>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style25">Nombre:</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style18">Apellido:</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtApellido" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style29"></td>
                </tr>
                <tr>
                    <td class="auto-style32">
                        &nbsp;</td>
                    <td class="auto-style11">DNI:</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtDNI" runat="server" AutoPostBack ="true" OnTextChanged="txtDNI_TextChanged" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe de ingresar solo numeros" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                        <asp:Label ID="lblDniIngresado" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style19">Sexo:</td>
                    <td class="auto-style24">
                        <asp:DropDownList ID="ddlSexo" runat="server" ValidationGroup="grupo1">
                            <asp:ListItem Text="Seleccione"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                            <asp:ListItem Enabled="False">Masculino</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style31">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style34"></td>
                    <td class="auto-style35">Nacionalidad:</td>
                    <td class="auto-style36">
                        <asp:DropDownList ID="ddlNacionalidad" runat="server" ValidationGroup="grupo1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style37">Fecha de Nacimiento:</td>
                    <td class="auto-style36">
                        <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style38"></td>
                </tr>
                <tr>
                    <td class="auto-style39"></td>
                    <td class="auto-style40">Dirección:</td>
                    <td class="auto-style41">
                        <asp:TextBox ID="txtDireccion" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style42">Localidad:</td>
                    <td class="auto-style41">
                        <asp:DropDownList ID="ddlLocalidad" runat="server" ValidationGroup="grupo1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style43"></td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style25">Provincia:</td>
                    <td class="auto-style23">
                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" ValidationGroup="grupo1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style18">Correo Electrónico:</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe de ingresar un mail valido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style33"></td>
                </tr>
                <tr>
                    <td class="auto-style32">&nbsp;</td>
                    <td class="auto-style11">Teléfono:</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="txtTelefono" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTel" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe de ingresar solo numeros" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style19">Especialidad:</td>
                    <td class="auto-style24">
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" ValidationGroup="grupo1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style31">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style32">&nbsp;</td>
                    <td class="auto-style11">Días de Atención:</td>
                    <td class="auto-style24">
                        <asp:CheckBoxList ID="cblDias" runat="server"></asp:CheckBoxList>
                    </td>
                    <td class="auto-style19">Horario de atencion:<br />
                        a</td>
                    <td class="auto-style24">
                        <asp:DropDownList ID="ddlHora1" runat="server" ValidationGroup="grupo1"></asp:DropDownList>
                        Hs<br />
                        <asp:DropDownList ID="ddlHora2" runat="server" ValidationGroup="grupo1"></asp:DropDownList>
                        Hs<asp:RequiredFieldValidator ID="rfvHorario" runat="server" ControlToValidate="ddlHora1" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style31">&nbsp;</td>
                </tr>
            </table>
            <table class="auto-style6">
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" Height="33px" ValidationGroup="grupo1" />
                    </td>
                    <td class="auto-style28">
                        <asp:ValidationSummary ID="vsAgregar" runat="server" ForeColor="Red" ValidationGroup="grupo1" />
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
