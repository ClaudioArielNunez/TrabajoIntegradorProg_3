<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionDeTurnos.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.AsignacionDeTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignar turnos</title>
 <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
            width: 226px;
        }
        .auto-style6 {
            width: 226px;
        }
        .auto-style9 {
            height: 23px;
            width: 518px;
        }
        .auto-style10 {
            width: 518px;
        }
        .auto-style11 {
            height: 23px;
            width: 196px;
        }
        .auto-style12 {
            width: 196px;
        }
        .auto-style13 {
            text-align: right;
        }
        .auto-style14 {
            text-align: right;
            height: 201px;
        }
     .auto-style19 {
         width: 196px;
         height: 30px;
     }
     .auto-style20 {
         width: 226px;
         height: 30px;
     }
     .auto-style21 {
         width: 518px;
         height: 30px;
     }
     .auto-style22 {
         height: 30px;
     }
     .auto-style23 {
         width: 196px;
         height: 205px;
     }
     .auto-style24 {
         width: 226px;
         height: 205px;
     }
     .auto-style25 {
         width: 518px;
         height: 205px;
     }
     .auto-style26 {
         height: 205px;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style11">Usuario: <asp:Label ID="lbNombreUsuario" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Medicos</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlPacientes" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/AgregarPaciente.aspx">Pacientes</asp:HyperLink>
                    </td>
                    <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/Informes.aspx">Informes</asp:HyperLink>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" ValidationGroup="grupo2" />
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19"></td>
                    <td class="auto-style20"><h2>TURNOS</h2></td>
                    <td class="auto-style21"></td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <p class="auto-style13">
                            DNI de Paciente:</p>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="tbPaciente" runat="server" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPaciente" runat="server" ControlToValidate="tbPaciente" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPaciente" runat="server" ControlToValidate="tbPaciente" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="grupo1">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style22">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <p class="auto-style13">
                            Especialidad:</p>
                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" Width="104px" ValidationGroup="grupo1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="Red" InitialValue="--Seleccione--" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <p class="auto-style13">
                            Medico:</p>
                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" ValidationGroup="grupo1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMedico" runat="server" ControlToValidate="ddlMedico" ForeColor="Red" InitialValue="--Seleccione--" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10"></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style23">
                        <p class="auto-style14">
                            Dia:
                        </p>
                    </td>
                    <td class="auto-style24">
                        <asp:Calendar ID="CalDia" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnDayRender="CalDia_DayRender" OnSelectionChanged="CalDia_SelectionChanged" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </td>
                    <td class="auto-style25"></td>
                    <td class="auto-style26"></td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <p class="auto-style13">
                            Horario:</p>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlHorario" runat="server" ValidationGroup="grupo1">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHorario" runat="server" ControlToValidate="ddlHorario" ForeColor="Red" InitialValue="--Seleccione--" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style9"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style12">Motivo de consulta:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtMotivoConsulta" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="rfvMotivo" runat="server" ControlToValidate="txtMotivoConsulta" ValidationGroup="grupo1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style6">
                        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnGuardarTurno" runat="server" Text="Guardar" OnClick="btnGuardarTurno_Click" style="width: 68px" ValidationGroup="grupo1" />
                        </p>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
