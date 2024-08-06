using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                        CargarPacientes();
                        CargarSexo();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }

        }

        private void CargarPacientes()
        {
            NegocioPacientes negocio = new NegocioPacientes();
            DataTable ListadoPaciente = negocio.ListarPacientes();
            gvListPacientes.DataSource = ListadoPaciente;
            gvListPacientes.DataBind();
        }

        private void CargarSexo()
        {
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("--Seleccione--", "0"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            CargarPacientes();
            txtApellido.Text = "";
            txtDNI.Text = "";
            lblNotFound.Text = "";
        }
        //Busqueda por apellido
        protected void btnApellido_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "")
            {

                string apellido = txtApellido.Text;
                NegocioPacientes negocio = new NegocioPacientes();
                DataTable Busqueda = negocio.BuscarPorApellido(apellido);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    gvListPacientes.DataSource = Busqueda;
                    gvListPacientes.DataBind();
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con el apellido : " + apellido;
                    gvListPacientes.DataSource = null;
                    gvListPacientes.DataBind();
                    txtApellido.Text = "";
                }
            }
        }

        //Busqueda por DNI
        protected void btnDni_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text != "")
            {
                string dni = txtDNI.Text;
                NegocioPacientes negocio = new NegocioPacientes();
                DataTable Busqueda = negocio.BuscarPorDNI(dni);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    gvListPacientes.DataSource = Busqueda;
                    gvListPacientes.DataBind();
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con DNI = " + dni;
                    gvListPacientes.DataSource = null;
                    gvListPacientes.DataBind();
                    txtDNI.Text = "";
                }
            }
        }

        //Filtro por Sexo
        protected void btnSexo_Click(object sender, EventArgs e)
        {
            if (ddlSexo.SelectedValue != "-1")
            {
                string sexo = ddlSexo.SelectedItem.Value.ToString();
                NegocioPacientes negocio = new NegocioPacientes();
                DataTable Busqueda = negocio.FiltrarSexo(sexo);
                gvListPacientes.DataSource = Busqueda;
                gvListPacientes.DataBind();
            }
        }

        protected void gvListPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListPacientes.PageIndex = e.NewPageIndex;

            CargarPacientes();
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}