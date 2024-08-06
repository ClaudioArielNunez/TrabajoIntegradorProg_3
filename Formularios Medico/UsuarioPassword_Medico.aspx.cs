using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Medico
{
    public partial class UsuarioPassword_Medico : System.Web.UI.Page
    {
        NegocioUsuario negocioU = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreUsuario"] != null)
            {
                lblUsuario.Text = Session["NombreUsuario"].ToString();
            }
            else
            {
                Response.Redirect("~/LogIn.aspx");
            }
        }

        

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            string usuarioActual = txtUsuarioActual.Text;
            string nuevoUsuario = txtNuevoUsuario.Text;
            string contrasenaActual = txtContraseñaActual.Text;
            string nuevaContrasena = txtNuevaContraseña.Text;
            string confirmarContrasena = txtConfirmarContraseña.Text;

            if (usuarioActual == nuevoUsuario)
            {
                lblMensaje.Text = "El nuevo usuario debe de ser diferente al actual.";
                return;
            }

            if (nuevaContrasena == contrasenaActual)
            {
                lblMensaje.Text = "La nueva contraseña debe de ser diferente a la actual.";
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            bool exito = negocioU.CambiarUsuarioYContrasena(usuarioActual, nuevaContrasena, nuevoUsuario);

            if (exito)
            {
                lblMensaje.Text = "Usuario y contraseña actualizados correctamente.";
            }
            else
            {
                lblMensaje.Text = "Error al actualizar usuario y contraseña.";
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Response.Redirect("~/LogIn.aspx");
        }



    }
}