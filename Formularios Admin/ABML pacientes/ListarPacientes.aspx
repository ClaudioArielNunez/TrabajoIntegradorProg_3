<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPacientes.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes.ListarPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pacientes - Listado</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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

        .auto-style17 {
            height: 5px;
            width: 192px;
        }

        .auto-style18 {
            height: 5px;
            width: 167px;
        }

        .auto-style14 {
            height: 5px;
            margin-left: 40px;
        }

        .auto-style10 {
            width: 350px;
            height: 36px;
        }

        .auto-style11 {
            height: 36px;
        }

        .auto-style9 {
            width: 350px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">Usuario:
                        <asp:Label ID="lblUsuarioAdmin" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style19">
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Medicos</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/Formularios Admin/AsignacionDeTurnos.aspx">Turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style20">
                        <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/Informes.aspx">Informes</asp:HyperLink>
                    </td>
                    <td class="auto-style21">Opciones de Paciente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hAgregarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/AgregarPaciente.aspx">Agregar Paciente</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" />
                    </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style14">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:HyperLink ID="hlEliminarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/EliminarPaciente.aspx">Eliminar Paciente</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style10">Buscar Paciente por:</td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>

                <td class="auto-style9">DNI:&nbsp;
                    <asp:TextBox ID="txtDNI"  placeholder="Dni" runat="server" Width="115px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnDni" runat="server"  Text="Buscar por DNI" OnClick="btnDni_Click" />

                </td>

            </tr>
            <tr>
                <td class="auto-style9">Apellido:&nbsp;
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnApellido"  OnClick="btnApellido_Click" runat="server" Text="Buscar por Apellido" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">Sexo:
                    <asp:DropDownList ID="ddlSexo" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSexo" runat="server"  Text="Filtrar por sexo" OnClick="btnSexo_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnQuitarFiltros0" runat="server" Text="Ver Lista Completa" OnClick="btnQuitarFiltros_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblNotFound" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="gvListPacientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="134px" Width="761px" AllowPaging="True" OnPageIndexChanging="gvListPacientes_PageIndexChanging" PageSize="5">
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
    </form>
</body>
</html>
