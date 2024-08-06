using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_medicos
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        NegocioMedicos negMed = new NegocioMedicos();
        NegocioProvincias negProv = new NegocioProvincias();
        NegocioLocalidades negLoc = new NegocioLocalidades();
        NegocioEspecialidades negEsp = new NegocioEspecialidades();
        NegocioNacionalidades negNac = new NegocioNacionalidades();
        NegocioDias negDias = new NegocioDias();
        NegocioHorarios negHora = new NegocioHorarios();
        NegocioMedicosxDiasxHorarios negMDH = new NegocioMedicosxDiasxHorarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                        CargarSexo();
                        CargarNacionalidad();
                        CargarProvincia();
                        CargarLocalidades(0);
                        CargarEspecialidad();
                        CargarDias();
                        CargarHorarios();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }

            lblMensaje.Text = "";
        }

        private void CargarSexo()
        {
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("--Seleccione--", "0"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
        }

        private void CargarNacionalidad()
        {
            bool emptyList = true;
            foreach (DataRow item in negNac.ListarNacionalidades().Rows)
            {
                if (emptyList)
                {
                    ddlNacionalidad.Items.Add(new ListItem("--Seleccione--", "0"));
                    emptyList = false;
                }
                ddlNacionalidad.Items.Add(new ListItem(item["Nacionalidad"].ToString(), item["ID_Nacionalidad"].ToString()));
            }
        }
        private void CargarProvincia()
        {
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Add(new ListItem("--Seleccione--", "0"));
            foreach (DataRow item in negProv.ListarProvincias().Rows)
            {
                ddlProvincia.Items.Add(new ListItem(item["Nombre"].ToString(), item["ID_Provincia"].ToString()));
            }
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvincia.SelectedValue);
            if (idProvincia > 0)
            {
                CargarLocalidades(idProvincia);
            }
            else
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("--Seleccione--", "0"));
            }
        }
        private void CargarLocalidades(int idProvincia)
        {
            ddlLocalidad.Items.Clear();
            DataTable dtLocalidades = negLoc.ObtenerLocalidadesPorProvincia(idProvincia);

            if (dtLocalidades.Rows.Count > 0)
            {
                ddlLocalidad.Items.Add(new ListItem("--Seleccione--", "0"));
                foreach (DataRow item in dtLocalidades.Rows)
                {
                    ddlLocalidad.Items.Add(new ListItem(item["Nombre"].ToString(), item["ID_Localidad"].ToString()));
                }
            }
            else
            {
                ddlLocalidad.Items.Add(new ListItem("--Seleccione--", "0"));
            }
        }
        private void CargarEspecialidad()
        {
            bool emptyList = true;
            foreach (DataRow item in negEsp.ListarEspecialidades().Rows)
            {
                if (emptyList)
                {
                    ddlEspecialidad.Items.Add(new ListItem("--Seleccione--", "0"));
                    emptyList = false;
                }
                ddlEspecialidad.Items.Add(new ListItem(item["Nombre"].ToString(), item["ID_Especialidad"].ToString()));
            }
        }

        private void CargarDias()
        {
            DataTable dtDias = negDias.ListarDias(); // Método que obtiene los días desde la base de datos
            foreach (DataRow row in dtDias.Rows)
            {
                cblDias.Items.Add(new ListItem(row["Dia"].ToString(), row["ID_Dia"].ToString()));
            }
        }
        private void CargarHorarios()
        {
            bool emptyList = true;
            foreach (DataRow item in negHora.ListarHorarios().Rows)
            {
                if (emptyList)
                {
                    ddlHora1.Items.Add(new ListItem("--Seleccione--", "0"));
                    ddlHora2.Items.Add(new ListItem("--Seleccione--", "0"));
                    emptyList = false;
                }
                ddlHora1.Items.Add(new ListItem(item["Hora_Turno"].ToString(), item["ID_Horario"].ToString()));
                ddlHora2.Items.Add(new ListItem(item["Hora_Turno"].ToString(), item["ID_Horario"].ToString()));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {                
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDNI.Text;
                string sexo = ddlSexo.Text;
                string nacionalidad = ddlNacionalidad.SelectedItem.Value;
                string fechaNacimiento = txtFechaNacimiento.Text;
                string direccion = txtDireccion.Text;
                string localidad = ddlLocalidad.SelectedItem.Value;
                string provincia = ddlProvincia.SelectedItem.Value;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                string especialidad = ddlEspecialidad.SelectedItem.Value;

                int horarioInicio = int.Parse(ddlHora1.SelectedItem.Value);
                int horarioFin = int.Parse(ddlHora2.SelectedItem.Value);

                int legajo = negMed.AgregarMedico(nombre, apellido, dni, sexo, nacionalidad, fechaNacimiento, direccion, localidad, provincia, email, telefono, especialidad/*, diasSelec, horarioInicio, horarioFin*/);
                int dia;
                                
                if (legajo > 0)
                {                    
                    // Iterar sobre los elementos del RadioButtonList
                    foreach (ListItem item in cblDias.Items)
                    {
                        if (item.Selected)
                        {
                            //por cada dia seleccionado le mando el legajo, el dia y los horarios
                            dia = Convert.ToInt32(item.Value);
                            negMDH.AgregarDiasHorariosMedico(legajo, dia, horarioInicio, horarioFin);
                        }
                    }
               
                    lblMensaje.Text = "El médico se ha agregado con éxito.";
                }
                else
                {
                    lblMensaje.Text = "No se ha podido agregar el médico.";
                }

                LimpiarControles();
                //temporizador para limpiar mensaje
                Response.AddHeader("Refresh", "3;url=AgregarMedico.aspx");
            }
            else
            {
                lblMensaje.Text = "Todos los campos deben ser válidos y estar completos.";
            }
        }
        
        private bool CamposCompletos()
        {
            bool diaSeleccionado = false;
            foreach (ListItem item in cblDias.Items)
            {
                if (item.Selected)
                {
                    diaSeleccionado = true;
                    break;
                }
            }

            return !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                   !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                   !string.IsNullOrWhiteSpace(txtDNI.Text) &&
                   ddlSexo.SelectedIndex > 0 &&
                   ddlNacionalidad.SelectedIndex > 0 &&
                   !string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) &&
                   !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                   ddlLocalidad.SelectedIndex > 0 &&
                   ddlProvincia.SelectedIndex > 0 &&
                   !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                   !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                   ddlEspecialidad.SelectedIndex > 0 &&
                   diaSeleccionado &&
                   ddlHora1.SelectedIndex > 0 &&
                   ddlHora2.SelectedIndex > 0 &&
                   lblDniIngresado.Text == "";
        }
        void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            ddlSexo.SelectedIndex = 0;
            ddlNacionalidad.SelectedIndex = 0;
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
            foreach (ListItem item in cblDias.Items)
            {
                item.Selected = false;
            }
            ddlHora1.SelectedIndex = 0;
            ddlHora2.SelectedIndex = 0;
        }
        //Chequeamos no se ingresen dni ya ingresados
        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dniIngresado = txtDNI.Text;
            string dniBuscado;
            List<string> lista = new List<string>();
            lista = CargarDniMedicos();
            dniBuscado = lista.Find(dni => dni.Equals(dniIngresado));
            if (dniBuscado != null)
            {
                lblDniIngresado.Text = "DNI YA INGRESADO!";

            }
            else
            {
                lblDniIngresado.Text = "";
            }
        }

        private List<string> CargarDniMedicos()
        {
            return negMed.ListarDni();
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}