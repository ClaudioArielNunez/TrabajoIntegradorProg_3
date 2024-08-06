using Negocio;
using System;
using System.Web.UI.WebControls;
using System.Data;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_medicos
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        NegocioEspecialidades negEsp = new NegocioEspecialidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                        CargarMedicos();
                        CargarEspecialidad();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
            
        }

        private void CargarMedicos()
        {
            NegocioMedicos negocio = new NegocioMedicos();
            DataTable ListadoMedico = negocio.ListarMedicos();
            dgvListadoMed.DataSource = ListadoMedico;
            dgvListadoMed.DataBind();
        }

        private void CargarEspecialidad()
        {
            bool emptyList = true;
            foreach (DataRow item in negEsp.ListarEspecialidades().Rows)
            {
                if (emptyList)
                {
                    ddlEspecialidad.Items.Add("--Seleccione--");
                    emptyList = false;
                }
                ddlEspecialidad.Items.Add(item["Nombre"].ToString());
            }
        }
        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            CargarMedicos();
            txtApellido.Text = "";
            txtDni.Text = "";
            lblNotFound.Text = "";
        }
        //Busqueda por apellido
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "")
            {

                string apellido = txtApellido.Text;
                NegocioMedicos negocio = new NegocioMedicos();
                DataTable Busqueda = negocio.BuscarPorApellido(apellido);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    dgvListadoMed.DataSource = Busqueda;
                    dgvListadoMed.DataBind();
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con el apellido : " + apellido;
                    dgvListadoMed.DataSource = null;
                    dgvListadoMed.DataBind();
                    txtApellido.Text = "";
                }
            }
        }

        //Busqueda por DNI
        protected void btnDni_Click(object sender, EventArgs e)
        {
            if (txtDni.Text != "")
            {
                string dni = txtDni.Text;
                NegocioMedicos negocio = new NegocioMedicos();
                DataTable Busqueda = negocio.BuscarPorDNI(dni);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    dgvListadoMed.DataSource = Busqueda;
                    dgvListadoMed.DataBind();
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con DNI = " + dni;
                    dgvListadoMed.DataSource = null;
                    dgvListadoMed.DataBind();
                    txtDni.Text = "";
                }
            }
        }

        //Filtro por especialidad
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (ddlEspecialidad.SelectedValue != "-1")
            {
                string especialidad = ddlEspecialidad.SelectedItem.Text.ToString();
                NegocioMedicos negocio = new NegocioMedicos();
                DataTable Busqueda = negocio.FiltrarEspecialidad(especialidad);
                dgvListadoMed.DataSource = Busqueda;
                dgvListadoMed.DataBind();
            }
        }

        protected void dgvListadoMed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoMed.PageIndex = e.NewPageIndex;
            CargarMedicos();
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}