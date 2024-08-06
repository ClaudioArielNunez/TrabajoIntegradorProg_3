using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Medico
{
    public partial class Inicio_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["NombreUsuario"] != null)
                {
                    lblUsuario.Text = Session["NombreUsuario"].ToString();
                }
                else
                {
                    Response.Redirect("~/LogIn.aspx");
                }
                
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}