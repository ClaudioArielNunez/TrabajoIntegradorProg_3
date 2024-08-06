<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosAsignados.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Medico.TurnosAsignados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Turnos del Médico</title>
    <style type="text/css">
        .auto-style1 {
            width: 932px;
        }

        .auto-style2 {
            width: 100%;
        }

        .auto-style3 {
            width: 358px;
        }

        .auto-style4 {
            width: 125px;
        }

        .auto-style6 {
            width: 138px;
        }

        .auto-style8 {
            width: 41%;
        }

        .auto-style9 {
            margin-left: 0px;
        }

        .auto-style10 {
            width: 132px;
        }

        .auto-style11 {
            width: 187px;
        }

        .auto-style14 {
            width: 89px;
        }

        .auto-style15 {
            width: 87px;
        }

        .auto-style16 {
            width: 125px;
            height: 45px;
        }

        .auto-style17 {
            width: 187px;
            height: 45px;
        }

        .auto-style18 {
            width: 138px;
            height: 45px;
        }

        .auto-style19 {
            width: 132px;
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style8">Usuario:
                        <asp:Label ID="lblUsuario" runat="server" /></td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Medico/Inicio_Medicos.aspx" Font-Size="Medium">Volver a inicio</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnLogout_Click" CssClass="auto-style9" ValidationGroup="grupo3" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <h1>Turnos del Médico</h1>

            <!-- Filtrado y búsqueda de turnos -->
            <table class="auto-style2">
                <tr>
                    <td class="auto-style16">Buscar por DNI:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtBuscarDNI" runat="server" Placeholder="Buscar por DNI de paciente" ValidationGroup="grupo1" Width="237px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvDNI" runat="server" ControlToValidate="txtBuscarDNI" ValidationGroup="grupo1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegValDNI" runat="server" ControlToValidate="txtBuscarDNI" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="grupo1">Debe ingresar sólo números</asp:RegularExpressionValidator>
                        &nbsp; </td>
                    <td class="auto-style14" rowspan="2">
                        <asp:Button ID="btnBuscarDNI" runat="server" Text="Buscar DNI" OnClick="btnBuscarDNI_Click" ValidationGroup="grupo1" />
                        <asp:Button ID="btnBuscarApellido" runat="server" OnClick="btnBuscarApellido_Click" Text="Buscar Apellido" ValidationGroup="grupo5" />
                    </td>
                    <td class="auto-style18">&nbsp;Filtrar por Mes:</td>
                    <td class="auto-style19">
                        <asp:DropDownList ID="ddlFiltrarFecha" runat="server" ValidationGroup="grupo2">
                            <asp:ListItem Selected="True" Value="0">--Todos los Meses--</asp:ListItem>
                            <asp:ListItem Value="1" Text="Enero" />
                            <asp:ListItem Value="2" Text="Febrero" />
                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                            <asp:ListItem Value="4">Abril</asp:ListItem>
                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                            <asp:ListItem Value="6">Junio</asp:ListItem>
                            <asp:ListItem Value="7">Julio</asp:ListItem>
                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                            <asp:ListItem Value="9">Septiembre</asp:ListItem>
                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style15" rowspan="2">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" Height="32px" Width="51px" OnClick="btnFiltrar_Click" ValidationGroup="grupo2" />

                    </td>
                    <td rowspan="2">
                        <asp:Button ID="btnQuitarFiltros" runat="server" Text="Quitar filtros" Height="32px" Width="85px" OnClick="btnQuitarFiltros_Click" ValidationGroup="grupo4" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Buscar por apellido:&nbsp;&nbsp; </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtBuscarApellido" runat="server" Placeholder="Buscar por apellido de paciente" Width="168px" ValidationGroup="grupo5"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtBuscarApellido" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="grupo5">*</asp:RequiredFieldValidator>
&nbsp;</td>
                    <td class="auto-style6">&nbsp;Filtrar por Asistencia:</td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="ddlFiltrarAsistencia" runat="server" ValidationGroup="grupo2">
                            <asp:ListItem Selected="True" Value="-1">--Todas las asistencias--</asp:ListItem>
                            <asp:ListItem Value="1" Text="Presentes" />
                            <asp:ListItem Value="0" Text="Ausentes" />
                        </asp:DropDownList>
                        &nbsp; </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;<br />

            <!-- GridView para mostrar los turnos -->
            <asp:Label ID="lblAviso" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="gvTurnos_RowEditing" OnRowCancelingEdit="gvTurnos_RowCancelingEdit" OnRowUpdating="gvTurnos_RowUpdating">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="ID_Turno">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_edit_ID_Turno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                          <asp:Label ID="lbl_id_turno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo de la consulta">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_motivo" runat="server" Text='<%# Bind("Motivo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Asistencia">
                        
                        <EditItemTemplate>
                            <asp:CheckBox ID="ChkEstadoEdit" runat="server" Checked='<%# Bind("Asistencia") %>' />
                        </EditItemTemplate>
                        
                        <ItemTemplate>                           
                            <asp:CheckBox ID="ChkEstado" Enabled="false" runat="server" Checked='<%# Bind("Asistencia") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observaciones">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Bind("Observaciones") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_observaciones" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
