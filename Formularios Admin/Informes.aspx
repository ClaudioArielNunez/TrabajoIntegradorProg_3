<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Informes</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 240px;
        }
        .auto-style4 {
            width: 256px;
        }
        .auto-style5 {
            width: 251px;
        }
        .auto-style6 {
            width: 242px;
        }
        .auto-style8 {
            width: 200px;
        }
        .auto-style10 {
            width: 281px;
        }
        .auto-style11 {
            width: 199px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style10">Usuario: <asp:Label ID="lblUsuarioAdmin" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style8">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Medicos</asp:HyperLink>
                        </td>
                        <td class="auto-style11">
                        <asp:HyperLink ID="hlPacientes" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/AgregarPaciente.aspx">Pacientes</asp:HyperLink>
                        </td>
                        <td>
                        <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/AsignacionDeTurnos.aspx">Turnos</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" ValidationGroup="grupo3" />
                        </td>
                        <td class="auto-style8">
                            &nbsp;</td>
                        <td class="auto-style11">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reportes</h1>

            <h2>Reporte de Asistencias y Ausencias de Pacientes</h2>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Fecha de inicio:
            <asp:TextBox ID="txtFechaInicioAA" runat="server" TextMode="Date" ValidationGroup="grupo1" OnTextChanged="txtFechaInicioAA_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAsisAusen" runat="server" ControlToValidate="txtFechaInicioAA" ErrorMessage="*" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">Fecha de fin:
            <asp:TextBox ID="txtFechaFinAA" runat="server" TextMode="Date" ValidationGroup="grupo1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAsisAusen2" runat="server" ControlToValidate="txtFechaFinAA" ErrorMessage="*" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td>
                        <asp:Button ID="btnGenerarInfAsisAus" runat="server" OnClick="btnGenerarInfAsisAus_Click" Text="Generar reporte" ValidationGroup="grupo1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <h2>Reporte de Turnos por Especialidad</h2>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">Fecha inicio:
            <asp:TextBox ID="txtFechaInicioTE" runat="server" TextMode="Date" ValidationGroup="grupo2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTEinicio" runat="server" ControlToValidate="txtFechaInicioTE" ErrorMessage="*" ForeColor="Red" ValidationGroup="grupo2"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style6">Fecha de fin:
            <asp:TextBox ID="txtFechaFinTE" runat="server" TextMode="Date" ValidationGroup="grupo2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTEfin" runat="server" ControlToValidate="txtFechaFinTE" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="grupo2"></asp:RequiredFieldValidator>
                    </td>
                    <td>
            <asp:Button ID="btnGenerarInformeTE" runat="server" Text="Generar reporte" OnClick="btnGenerarInformeTE_Click" ValidationGroup="grupo2" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblAclaracion" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvInformes" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>