﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarPaciente.aspx.cs" Inherits="TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes.EliminarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pacientes - Eliminar</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 177px;
        }

        .auto-style3 {
            text-align: right;
        }

        .auto-style4 {
            width: 214px;
        }

        .auto-style5 {
            width: 117px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Usuario:
                    <asp:Label ID="lbNombreUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="hlMedicos" runat="server" NavigateUrl="~/Formularios Admin/ABML medicos/AgregarMedico.aspx">Medicos</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/Formularios Admin/AsignacionDeTurnos.aspx">Turnos</asp:HyperLink>
                </td>
                <td class="auto-style5">
                    <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Formularios Admin/Informes.aspx">Informes</asp:HyperLink>
                </td>
                <td>Opciones de Paciente:
                    <asp:HyperLink ID="hlAgregarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/AgregarPaciente.aspx">Agregar Paciente</asp:HyperLink>
                    &nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCerrarSession" runat="server" OnClick="btnCerrarSession_Click" Text="Cerrar Sesión" />
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="hlListarPaciente" runat="server" NavigateUrl="~/Formularios Admin/ABML pacientes/ListarPacientes.aspx">Listar Paciente</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">Eliminar o Modificar paciente</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <p class="auto-style3">
                        Buscar por ID:
                    </p>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtIdPaciente" runat="server" Width="197px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="lblNotFound" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btn_Volver" runat="server" OnClick="btn_Volver_Click" Text="Volver al Listado" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
        <asp:GridView ID="gvListPacientes" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="16px" Width="661px" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvListPacientes_PageIndexChanging" OnRowCancelingEdit="gvListPacientes_RowCancelingEdit" OnRowDeleting="gvListPacientes_RowDeleting" OnRowEditing="gvListPacientes_RowEditing" OnRowUpdating="gvListPacientes_RowUpdating" OnRowDataBound="gvListPacientes_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:Label ID="lbl_ed_IdPaciente" runat="server" Text='<%# Bind("ID_Paciente") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_id_Paciente" runat="server" Text='<%# Bind("ID_Paciente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DNI">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Dni" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_ed_Dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sexo">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_ed_Sexo" runat="server">
                            <asp:ListItem>F</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>O</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nacionalidad">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_ed_Nacionalidad" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de Nacimiento">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Fecha" runat="server" Text='<%# Bind("Fecha_Nacimiento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_fechaNacim" runat="server" Text='<%# Bind("Fecha_Nacimiento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Direccion">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Localidad">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_ed_Localidad" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Provincia">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_ed_Provincia" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo Electronico">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Correo" runat="server" Text='<%# Bind("Correo_Electronico") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_correo" runat="server" Text='<%# Bind("Correo_Electronico") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefono">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_ed_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
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
        <%--confirmacion de borrado--%>
        <br />
        <br />
        <asp:Label ID="lblConfirmarDelete" runat="server"></asp:Label>
        <asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Aceptar" Visible="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirmar2" runat="server" OnClick="btnConfirmar2_Click" Text="Cancelar" Visible="False" />
        <%---------------------------%>
    </form>
</body>
</html>
