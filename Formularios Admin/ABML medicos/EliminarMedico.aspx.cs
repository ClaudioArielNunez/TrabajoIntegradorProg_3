using DAO;
using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_medicos
{
    public partial class EliminarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                //CargarMedicos();
                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                        CargarMedicos();
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

        protected void dgvListadoMed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblConfirmarDelete.Text = "¿Está seguro que desea eliminar al medico?";
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            string Id_Medico = ((Label)dgvListadoMed.Rows[e.RowIndex].FindControl("lbl_it_LegajoMed")).Text;
            Session["Id_Medico"] = Id_Medico;

            e.Cancel = true;

            
        }

        protected void dgvListadoMed_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvListadoMed.EditIndex = e.NewEditIndex;
            string Id_Medico = ((Label)dgvListadoMed.Rows[e.NewEditIndex].FindControl("lbl_it_LegajoMed")).Text;
            NegocioMedicos negocio = new NegocioMedicos();
            DataTable datosMedico = negocio.BuscarPorId(Id_Medico);
            dgvListadoMed.DataSource= datosMedico;
            dgvListadoMed.DataBind();
            //CargarMedicos();
        }

        protected void dgvListadoMed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvListadoMed.EditIndex = -1;
            CargarMedicos();
        }

        protected void dgvListadoMed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Id_Medico = ((Label)dgvListadoMed.Rows[e.RowIndex].FindControl("lbl_edit_Legajo")).Text;
            string dni = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_DNI")).Text;
            string nombre = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_Nombre")).Text;
            string apellido = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_Apellido")).Text;
            string sexo = ((DropDownList)dgvListadoMed.Rows[e.RowIndex].FindControl("ddl_ed_Sexo")).SelectedValue;
            string nacionalidad = ((DropDownList)dgvListadoMed.Rows[e.RowIndex].FindControl("ddl_ed_Nacionalidad")).SelectedValue;
            string especialidad = ((DropDownList)dgvListadoMed.Rows[e.RowIndex].FindControl("ddl_ed_Especialidad")).SelectedValue;
            string fecha = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_Fecha")).Text;
            string direccion = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_Direccion")).Text;
            string localidad = ((DropDownList)dgvListadoMed.Rows[e.RowIndex].FindControl("ddl_ed_Localidad")).SelectedValue;
            string provincia = ((DropDownList)dgvListadoMed.Rows[e.RowIndex].FindControl("ddl_ed_Provincias")).SelectedValue;
            string correo = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_Correo")).Text;
            string telefono = ((TextBox)dgvListadoMed.Rows[e.RowIndex].FindControl("txt_ed_telefono")).Text;

            Medico medico = new Medico();
            medico.Legajo = Convert.ToInt32(Id_Medico);
            medico.DNI = dni;
            medico.Nombre = nombre;
            medico.Apellido = apellido;
            medico.Sexo = char.Parse(sexo);
            medico.Nacionalidad = int.Parse(nacionalidad);
            medico.IDEspecialidad = int.Parse(especialidad);
            medico.FechaNacimiento = Convert.ToDateTime(fecha);
            medico.Direccion = direccion;
            medico.IDLocalidad = int.Parse(localidad);
            medico.IDProvincia = int.Parse(provincia);
            medico.CorreoElectronico = correo;
            medico.Telefono = telefono;

            NegocioMedicos negocio = new NegocioMedicos();
            negocio.ActualizarMedico(medico);

            dgvListadoMed.EditIndex = -1;
            CargarMedicos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdMedico.Text != "")
            {

                string Id_Medico = txtIdMedico.Text;
                NegocioMedicos negocio = new NegocioMedicos();
                DataTable Busqueda = negocio.BuscarPorId(Id_Medico);
                if (Busqueda != null && Busqueda.Rows.Count > 0)
                {
                    lblNotFound.Text = "";
                    dgvListadoMed.DataSource = Busqueda;
                    dgvListadoMed.DataBind();
                    
                }
                else
                {
                    lblNotFound.Text = "No se encontraron registros con el Id : " + Id_Medico;
                    dgvListadoMed.DataSource = null;
                    dgvListadoMed.DataBind();
                    
                }
                txtIdMedico.Text = "";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            CargarMedicos();
            txtIdMedico.Text = "";
            lblNotFound.Text = "";
        }

        protected void dgvListadoMed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoMed.PageIndex = e.NewPageIndex;
            CargarMedicos();
        }

        protected void dgvListadoMed_RowDataBound(object sender, GridViewRowEventArgs e)
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

                DropDownList ddl_Provincias = (DropDownList)e.Row.FindControl("ddl_ed_Provincias");
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

                DropDownList ddl_Especialidad = (DropDownList)e.Row.FindControl("ddl_ed_Especialidad");
                if (ddl_Especialidad != null)
                {
                    DatosEspecialidades datos = new DatosEspecialidades();
                    ddl_Especialidad.DataSource = datos.ObtenerEspecialidades();
                    ddl_Especialidad.DataTextField = "Nombre";
                    ddl_Especialidad.DataValueField = "ID_Especialidad";                    
                    ddl_Especialidad.DataBind();

                    string especialidad = DataBinder.Eval(e.Row.DataItem, "Especialidad").ToString();
                    ddl_Especialidad.Items.FindByText(especialidad).Selected = true;
                }
            }
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Session["Id_Medico"] != null)
            {
                int IdMedico = Convert.ToInt32(Session["Id_Medico"]);

                Medico medico = new Medico();
                medico.Legajo = IdMedico;

                NegocioMedicos negocio = new NegocioMedicos();
                negocio.DeleteLogico(medico);

                CargarMedicos();
            }
            Session["Id_Medico"] = null;
            lblConfirmarDelete.Text = "";
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Id_Medico"] = null;
            lblConfirmarDelete.Text = "";
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}