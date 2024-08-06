using DAO;
using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes
{
    public partial class EliminarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lbNombreUsuario.Text = Session["NombreUsuario"].ToString();
                        CargarPaciente();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
            
        }

        private void CargarPaciente()
        {
            NegocioPacientes negocio = new NegocioPacientes();
            DataTable ListadoPaciente = negocio.ListarPacientes();
            gvListPacientes.DataSource = ListadoPaciente;
            gvListPacientes.DataBind();
        }

        protected void gvListPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListPacientes.PageIndex = e.NewPageIndex;
            CargarPaciente();
        }

        protected void gvListPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblConfirmarDelete.Text = "¿Está seguro que desea eliminar al paciente?";
            btnConfirmar.Visible = true;
            btnConfirmar2.Visible = true;

            string Id_Paciente = ((Label)gvListPacientes.Rows[e.RowIndex].FindControl("lbl_id_Paciente")).Text;
            Session["Id_Paciente"] = Id_Paciente;

            e.Cancel = true;
            
        }

        protected void gvListPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvListPacientes.EditIndex = e.NewEditIndex;
            string Id_Paciente = ((Label)gvListPacientes.Rows[e.NewEditIndex].FindControl("lbl_id_Paciente")).Text;            
            NegocioPacientes negocio = new NegocioPacientes();
            DataTable datosPaciente = negocio.BuscarPorId(Id_Paciente);            
            gvListPacientes.DataSource = datosPaciente;
            gvListPacientes.DataBind();
            
        }

        protected void gvListPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvListPacientes.EditIndex = -1;
            CargarPaciente();
        }

        protected void gvListPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ddl de genero
                DropDownList ddl_Sexo = (DropDownList)e.Row.FindControl("ddl_ed_Sexo");
                if (ddl_Sexo != null)
                {
                    string sexo = DataBinder.Eval(e.Row.DataItem, "Sexo").ToString();
                    ddl_Sexo.Items.FindByText(sexo).Selected = true;
                }

                DropDownList ddl_Nacionalidad = (DropDownList)e.Row.FindControl("ddl_ed_Nacionalidad");
                if (ddl_Nacionalidad != null)
                {
                    DatosNacionalidades datos = new DatosNacionalidades();
                    ddl_Nacionalidad.DataSource = datos.ObtenerNacionalidades();
                    ddl_Nacionalidad.DataTextField = "Nacionalidad";
                    ddl_Nacionalidad.DataValueField = "ID_Nacionalidad";
                    ddl_Nacionalidad.DataBind();

                    string nacionalidad = DataBinder.Eval(e.Row.DataItem, "Nacionalidad").ToString();
                    ddl_Nacionalidad.Items.FindByText(nacionalidad).Selected = true;
                }

                DropDownList ddl_localidades = (DropDownList)e.Row.FindControl("ddl_ed_Localidad");
                if (ddl_localidades != null)
                {
                    DatosLocalidades datos = new DatosLocalidades();
                    ddl_localidades.DataSource = datos.ObtenerLocalidades();
                    ddl_localidades.DataTextField = "Nombre";
                    ddl_localidades.DataValueField = "ID_Localidad";
                    ddl_localidades.DataBind();

                    string localidad = DataBinder.Eval(e.Row.DataItem, "Localidad").ToString();
                    ddl_localidades.Items.FindByText(localidad).Selected = true;
                }

                DropDownList ddl_Provincias = (DropDownList)e.Row.FindControl("ddl_ed_Provincia");
                if (ddl_Provincias != null)
                {
                    DatosProvincias datos = new DatosProvincias();
                    ddl_Provincias.DataSource = datos.ObtenerProvincias();
                    ddl_Provincias.DataTextField = "Nombre";
                    ddl_Provincias.DataValueField = "ID_Provincia";
                    ddl_Provincias.DataBind();

                    string provincia = DataBinder.Eval(e.Row.DataItem, "Provincia").ToString();
                    ddl_Provincias.Items.FindByText(provincia).Selected = true;
                }
            }
        }

        protected void gvListPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Id_Paciente = ((Label)gvListPacientes.Rows[e.RowIndex].FindControl("lbl_ed_IdPaciente")).Text;
            string dni = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Dni")).Text;
            string nombre = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Nombre")).Text;
            string apellido = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Apellido")).Text;
            string sexo = ((DropDownList)gvListPacientes.Rows[e.RowIndex].FindControl("ddl_ed_Sexo")).SelectedValue;
            string nacionalidad = ((DropDownList)gvListPacientes.Rows[e.RowIndex].FindControl("ddl_ed_Nacionalidad")).SelectedValue;            
            string fecha = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Fecha")).Text;
            string direccion = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Direccion")).Text;
            string localidad = ((DropDownList)gvListPacientes.Rows[e.RowIndex].FindControl("ddl_ed_Localidad")).SelectedValue;
            string provincia = ((DropDownList)gvListPacientes.Rows[e.RowIndex].FindControl("ddl_ed_Provincia")).SelectedValue;
            string correo = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Correo")).Text;
            string telefono = ((TextBox)gvListPacientes.Rows[e.RowIndex].FindControl("txt_ed_Telefono")).Text;

            Paciente paciente = new Paciente();
            paciente.IDPaciente = Convert.ToInt32(Id_Paciente);
            paciente.DNI = dni;
            paciente.Nombre = nombre;
            paciente.Apellido = apellido;
            paciente.Sexo = char.Parse(sexo);
            paciente.Nacionalidad = int.Parse(nacionalidad);            
            paciente.FechaNacimiento = Convert.ToDateTime(fecha);
            paciente.Direccion = direccion;
            paciente.IDLocalidad = int.Parse(localidad);
            paciente.IDProvincia = int.Parse(provincia);
            paciente.CorreoElectronico = correo;
            paciente.Telefono = telefono;

            NegocioPacientes negocio = new NegocioPacientes();
            negocio.ActualizarPaciente(paciente);

            gvListPacientes.EditIndex = -1;
            CargarPaciente();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdPaciente.Text != "")
            {

                string Id_Paciente = txtIdPaciente.Text;
                NegocioPacientes negocio = new NegocioPacientes();
                DataTable Busqueda = negocio.BuscarPorId(Id_Paciente);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    lblNotFound.Text = "";
                    gvListPacientes.DataSource = Busqueda;
                    gvListPacientes.DataBind();
                    
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con el Id : " + Id_Paciente;
                    gvListPacientes.DataSource = null;
                    gvListPacientes.DataBind();
                    
                }
                txtIdPaciente.Text = "";
            }
        }

        protected void btn_Volver_Click(object sender, EventArgs e)
        {
            CargarPaciente();
            txtIdPaciente.Text = "";
            lblNotFound.Text = "";
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (Session["Id_Paciente"] != null)
            {
                int idPaciente = Convert.ToInt32(Session["Id_Paciente"]);

                Paciente paciente = new Paciente();
                paciente.IDPaciente = idPaciente;

                NegocioPacientes negocio = new NegocioPacientes();
                negocio.DeleteLogico(paciente);

                CargarPaciente();
            }
            Session["Id_Paciente"] = null;
            lblConfirmarDelete.Text = "";
            btnConfirmar.Visible = false;
            btnConfirmar2.Visible = false;
        }

        protected void btnConfirmar2_Click(object sender, EventArgs e)
        {
            Session["Id_Paciente"] = null;
            lblConfirmarDelete.Text = "";
            btnConfirmar.Visible = false;
            btnConfirmar2.Visible = false;
        }
    }
}