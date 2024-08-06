using Entidades;
using Negocio;
using System;
namespace TPINT_GRUPO_18_PR3_v1
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            NegocioMedicos negocio = new NegocioMedicos();


            if (rblTipoDeCuenta.SelectedValue == "Administrador")
            {
                Session["NombreUsuario"] = negocio.AccesoAlSistemaADMIN(txtUsuario.Text, txtContraseña.Text);
                Session["TipoUsuario"] = negocio.AccesoTipoUserAdmin(txtUsuario.Text, txtContraseña.Text);
                
                if (Session["NombreUsuario"].ToString() != "" && Session["NombreUsuario"].ToString() != string.Empty && int.Parse(Session["TipoUsuario"].ToString()) == 1)
                {

                    Response.Redirect("~/Formularios Admin/AsignacionDeTurnos.aspx");
                }
                else
                {
                    lblError.Text = "*El usuario o contraseña ingresado no es correcto";
                }
            }
            else
            {
                
                Session["NombreUsuario"] = negocio.AccesoAlSistemaMedico(txtUsuario.Text, txtContraseña.Text);
                Session["TipoUsuario"] = negocio.AccesoTipoUserMed(txtUsuario.Text, txtContraseña.Text);                
                
                if((Session["NombreUsuario"].ToString() != null && Session["NombreUsuario"].ToString() != string.Empty && int.Parse(Session["TipoUsuario"].ToString()) == 2))
                {
                    Session["Legajo"] = negocio.AccesoAlSistemaMedicoLegajo(txtUsuario.Text, txtContraseña.Text);
                    Response.Redirect("~/Formularios Medico/Inicio_Medicos.aspx");
                }
                else
                {
                    lblError.Text = "*El usuario o contraseña ingresado no es correcto";
                    lblError2.Text = "*Revisar que el Tipo de cuenta sea correcto*";
                }
            }



        }

       
    }
}