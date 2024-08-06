using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin.ABML_pacientes
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        NegocioPacientes negPac = new NegocioPacientes();
        NegocioProvincias negProv = new NegocioProvincias();
        NegocioLocalidades negLoc = new NegocioLocalidades();
        NegocioNacionalidades negNac = new NegocioNacionalidades();
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
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
            
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
        private void CargarSexo()
        {
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("--Seleccione--", "0"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
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
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {           
             
            Paciente nuevoPaciente = new Paciente();
            nuevoPaciente.DNI = txtDNI.Text;
            nuevoPaciente.Nombre = txtNombre.Text;
            nuevoPaciente.Apellido = txtApellido.Text;
            nuevoPaciente.Sexo = Convert.ToChar(ddlSexo.SelectedValue);
            nuevoPaciente.Nacionalidad = int.Parse(ddlNacionalidad.SelectedValue);
            nuevoPaciente.FechaNacimiento = DateTime.Parse(txtFechaNacim.Text);
            nuevoPaciente.Direccion = txtDireccion.Text;
            nuevoPaciente.CorreoElectronico = txtEmail.Text;
            nuevoPaciente.Telefono = txtTelefono.Text;
            nuevoPaciente.IDProvincia = int.Parse(ddlProvincia.SelectedValue);
            nuevoPaciente.IDLocalidad = int.Parse(ddlLocalidad.SelectedValue);            

            if(lblDniIngresado.Text == string.Empty)
            {
                
                int filas = negPac.AgregarPaciente(nuevoPaciente);
                if (filas > 0)
                {
                    lblAtencion.Text = "El paciente se ha agregado con exito!";
                    LimpiarControles();
                    //temporizador para limpiar mensaje
                    Response.AddHeader("Refresh", "3;url=AgregarPaciente.aspx");
                }
            }
            else
            {
                lblAtencion.Text = "Ya existe un paciente con ese numero de DNI";
            }

            
        }
        void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            ddlSexo.SelectedIndex = 0;
            ddlNacionalidad.SelectedIndex = 0;
            txtFechaNacim.Text = "";
            txtDireccion.Text = "";
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";           
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }

        //Chequeamos no se ingresen dni ya ingresados
        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dniIngresado = txtDNI.Text;
            string dniBuscado;
            List<string> lista = new List<string>();
            lista = CargarDniPacientes();
            dniBuscado = lista.Find(dni => dni.Equals(dniIngresado));
            if (dniBuscado != null)
            {
                lblDniIngresado.Text = "DNI YA INGRESADO!";
            }
            else
            {
                lblDniIngresado.Text = "";
                lblAtencion.Text = "";
            }
        }

        private List<string> CargarDniPacientes()
        {
            return negPac.ListaDniPacientes();
        }
    }
}