using System;
using System.Data;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Medico
{
    public partial class TurnosAsignados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreUsuario"] != null)
                {
                    lblUsuario.Text = Session["NombreUsuario"].ToString();
                    cargarTurnos();
                }
                else
                {
                    Response.Redirect("~/LogIn.aspx");
                }
            }

        }
        private void cargarTurnos()
        {
            int legajo = Convert.ToInt32(Session["Legajo"]);
            NegocioTurnos datos = new NegocioTurnos();
            
            DateTime fecha = DateTime.Today;
            DataTable listadoTurnos = datos.MostrarTurnosdelDIA(legajo, fecha);
            if (listadoTurnos != null && listadoTurnos.Rows.Count > 0)
            {
                gvTurnos.DataSource = listadoTurnos;
                gvTurnos.DataBind();                
            }
            else
            {
                gvTurnos.DataSource = null; // Limpia el GridView si no hay resultados
                gvTurnos.DataBind();                
                lblAviso.Text = "No hay turnos disponibles para el día de hoy.";
            }

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(Session["Legajo"]);
            int dni = Convert.ToInt32(txtBuscarDNI.Text);
            NegocioTurnos datos = new NegocioTurnos();
            DataTable listadoTurnos = datos.MostrarTurnosPorDNI(legajo, dni);
            if (listadoTurnos != null && listadoTurnos.Rows.Count > 0)
            {
                gvTurnos.DataSource = listadoTurnos;
                gvTurnos.DataBind();                
                lblAviso.Text = "";
            }
            else
            {
                gvTurnos.DataSource = null; // Limpia el GridView si no hay resultados
                gvTurnos.DataBind();                
                lblAviso.Text = "No hay turnos con ese DNI";
            }

            txtBuscarDNI.Text = "";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            int legajo = Convert.ToInt32(Session["Legajo"]);
            int mes = Convert.ToInt32(ddlFiltrarFecha.SelectedValue);
            int asistencia = Convert.ToInt32(ddlFiltrarAsistencia.SelectedValue);
            NegocioTurnos datos = new NegocioTurnos();
            DataTable listadoTurnos = datos.MostrarFiltrosTurnos(legajo, mes, asistencia);
            gvTurnos.DataSource = listadoTurnos;
            gvTurnos.DataBind();
            if(listadoTurnos.Rows.Count==0)
            {
                lblAviso.Text = "No hay turnos con esos filtros";
            }
        }

        protected void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            if(txtBuscarApellido.Text != null)
            {
                string apellido = txtBuscarApellido.Text;
                int legajo = Convert.ToInt32(Session["Legajo"]);
                NegocioTurnos datos = new NegocioTurnos();
                DataTable listadoTurnos = datos.MostrarTurnosPorApellido(legajo, apellido);
                if (listadoTurnos != null && listadoTurnos.Rows.Count > 0)
                {
                    gvTurnos.DataSource = listadoTurnos;
                    gvTurnos.DataBind();                    
                    lblAviso.Text = "";
                }
                else
                {
                    gvTurnos.DataSource = null; // Limpia el GridView si no hay resultados
                    gvTurnos.DataBind();                    
                    lblAviso.Text = "No hay turnos con ese apellido";
                }
                txtBuscarApellido.Text = "";

            }
        }

        protected void gvTurnos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            cargarTurnos();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            cargarTurnos();
        }

        protected void gvTurnos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            string id_Turno = ((Label)gvTurnos.Rows[e.RowIndex].FindControl("lbl_edit_ID_Turno")).Text;
            string estado = ((CheckBox)gvTurnos.Rows[e.RowIndex].FindControl("ChkEstadoEdit")).Checked.ToString();
            string observacion = ((TextBox)gvTurnos.Rows[e.RowIndex].FindControl("txtObservacion")).Text;
                        
            Turnos updTurno = new Turnos();
            updTurno.ID_turno1 = Convert.ToInt32(id_Turno);            
            updTurno.Paciente_presente = Convert.ToBoolean(estado);      
            
            updTurno.Observacion = observacion;

            NegocioTurnos datos = new NegocioTurnos();
            datos.ActualizarTurno(updTurno);

            gvTurnos.EditIndex = -1;
            cargarTurnos();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            cargarTurnos();
        }
    }
}