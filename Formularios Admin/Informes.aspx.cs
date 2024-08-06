using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using System.Globalization;
using Entidades;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin
{
    public partial class Informes : System.Web.UI.Page
    {
        NegocioTurnos negocio = new NegocioTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreUsuario"].ToString() != null)
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lblUsuarioAdmin.Text = Session["NombreUsuario"].ToString();
                        lblAclaracion.Text = "";
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }                
                
            }
        }

        protected void btnGenerarInfAsisAus_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(txtFechaInicioAA.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFinAA.Text);

            lblAclaracion.Text = "TOTAL EN EL PERIODO DE TIEMPO INDICADO";

                DataTable Informe = negocio.TotalAsistenciasAusencias(fechaInicio, fechaFin);
                gvInformes.DataSource = Informe;
                gvInformes.DataBind();
            
               
            

        }
        protected void btnGenerarInformeTE_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(txtFechaInicioTE.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFinTE.Text);

            lblAclaracion.Text = "Total de especialidades y los turnos asignados en las mismas.";

            DataTable Informe = negocio.TurnosPorEspecialidad(fechaInicio, fechaFin);
            gvInformes.DataSource = Informe;
            gvInformes.DataBind();
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }

        protected void txtFechaInicioAA_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}