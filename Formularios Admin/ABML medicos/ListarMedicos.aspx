<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedicos.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_medicos.ListarPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medicos - Listado</title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style8 {
            width: 245px;
        }
        .auto-style22 {
            width: 337px;
        }
        .auto-style25 {
            height: 23px;
        }
        .auto-style27 {
            height: 33px;
        }
        .auto-style28 {
            height: 33px;
            width: 294px;
        }
        .auto-style29 {
            height: 23px;
            width: 294px;
        }
        .auto-style30 {
            width: 294px;
        }
        .auto-style31 {
            height: 33px;
            width: 968px;
        }
        .auto-style32 {
            height: 23px;
            width: 968px;
        }
        .auto-style33 {
            width: 968px;
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
                <td>Opciones de Medico: <asp:HyperLink ID="hlAgregarMedico" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Agregar Médico</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" />
                </td>
                <td class="auto-style22">
                    &nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:HyperLink ID="hlModifEliminar" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/EliminarMedico.aspx">Editar/Eliminar Médico</asp:HyperLink>
                </td>
            </tr>
            </table>

        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style28">Buscar Médico Por:</td>
                <td class="auto-style31"></td>
                <td class="auto-style27"></td>
                <td class="auto-style27"></td>
            </tr>
            <tr>
                <td class="auto-style29">Dni:
                    <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style32">
                    <asp:Button ID="btnDni" runat="server" Text="Buscar por DNI" OnClick="btnDni_Click" />
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
            </tr>
            <%--<tr>
                <td class="auto-style28">Nombre:&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
            <tr>
                <td class="auto-style30">Apellido:
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style33">
                    <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" Text="Buscar por Apellido" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style30">Especialidad:
                    <br />
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Width="187px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style33">
                    <asp:Button ID="btnFiltro" runat="server" OnClick="btnFiltro_Click" Text="Filtrar por Especialidad" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <%--<td class="auto-style28">Sexo:
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>--%>
                <td class="auto-style30">
                    <asp:Button ID="btnQuitarFiltros" runat="server" Text="Ver Lista Completa" OnClick="btnQuitarFiltros_Click" />
                    <br />
                    <asp:Label ID="lblNotFound" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style33">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <%--<tr>
                <td class="auto-style28">Nacionalidad:
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">Provincia:&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
            </tr>--%><%-- <tr>
                <td class="auto-style24">Localidad:
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
            </tr>--%>
            <tr>
                <td class="auto-style25" colspan="4">                    
                    <asp:GridView ID="dgvListadoMed" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="134px" Width="761px" AllowPaging="True" OnPageIndexChanging="dgvListadoMed_PageIndexChanging" PageSize="5" >
                        <Columns>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sexo">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nacionalidad">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Especialidad">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Nacimiento">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha_Nacimiento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Localidad">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Provincia">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Correo Electronico">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Bind("Correo_Electronico") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telefono">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
