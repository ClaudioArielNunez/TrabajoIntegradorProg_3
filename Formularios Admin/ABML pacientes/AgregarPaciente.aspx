<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes.AgregarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pacientes - Agregar</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 30px;
        }

        .auto-style7 {
            width: 100%;
        }

        .auto-style9 {
            width: 632px;
        }

        .auto-style11 {
            width: 664px;
        }

        .auto-style12 {
            width: 98px;
        }

        .auto-style13 {
            width: 230px;
        }

        .auto-style14 {
            height: 5px;
            margin-left: 40px;
        }

        .auto-style15 {
            width: 455px;
        }

        .auto-style16 {
            width: 222px;
        }

        .auto-style17 {
            height: 5px;
            width: 192px;
        }

        .auto-style18 {
            height: 5px;
            width: 167px;
        }

        .auto-style19 {
            height: 29px;
            width: 192px;
        }

        .auto-style20 {
            height: 29px;
            width: 167px;
        }

        .auto-style21 {
            height: 29px;
            margin-left: 40px;
        }
        .auto-style22 {
            width: 230px;
            height: 30px;
        }
        .auto-style23 {
            width: 632px;
            height: 30px;
        }
        .auto-style24 {
            width: 664px;
            height: 30px;
        }
        .auto-style25 {
            width: 98px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">Usuario: <asp:Label ID="lblUsuarioAdmin" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style19">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Medicos</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/Formularios Admin/AsignacionDeTurnos.aspx">Turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style20">
                        <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/Informes.aspx">Informes</asp:HyperLink>
                    </td>
                    <td class="auto-style21">Opciones de Paciente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlEliminarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/EliminarPaciente.aspx">Eliminar Paciente</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" ValidationGroup="grupo2" />
                    </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style14">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:HyperLink ID="hlListarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/ListarPacientes.aspx">Listar Paciente</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Agregar Paciente</h1>

        </div>
        <table class="auto-style7">
            <tr>
                <td class="auto-style22"></td>
                <td class="auto-style23">DNI:
                    <asp:TextBox ID="txtDNI" runat="server" OnTextChanged="txtDNI_TextChanged" AutoPostBack="true" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe de ingresar solo numeros" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                    <asp:Label ID="lblDniIngresado" runat="server" ForeColor="Red"></asp:Label>
                    
                </td>
                <td class="auto-style24">Dirección:&nbsp;
                    <asp:TextBox ID="txtDireccion" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style25"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9">Nombre:&nbsp;
                    <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">Provincia:&nbsp;
                    <asp:DropDownList ID="ddlProvincia" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" runat="server" ValidationGroup="grupo1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9">Apellido:&nbsp;
                    <asp:TextBox ID="txtApellido" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">Localidad:&nbsp;
                    <asp:DropDownList ID="ddlLocalidad" runat="server" ValidationGroup="grupo1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9">Sexo:&nbsp;
                    <asp:DropDownList ID="ddlSexo" runat="server" ValidationGroup="grupo1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">Correo Electronico:&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe de ingresar un mail valido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                </td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style22"></td>
                <td class="auto-style23">Nacionalidad:&nbsp; 
                    <asp:DropDownList ID="ddlNacionalidad" runat="server" ValidationGroup="grupo1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" ForeColor="Red" InitialValue="0" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style24">Teléfono:&nbsp;
                    <asp:TextBox ID="txtTelefono" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTel" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe de ingresar solo numeros" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                </td>
                <td class="auto-style25"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style9">Fecha de Nacimiento:&nbsp;
                    <asp:TextBox ID="txtFechaNacim" TextMode="Date" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNacim" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style7">
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="grupo1" />
                </td>
                 <td class="auto-style28">
                        <asp:ValidationSummary ID="vsAgregar" runat="server" ForeColor="Red" ValidationGroup="grupo1" />
                    </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">
                    <asp:Label ID="lblAtencion" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
