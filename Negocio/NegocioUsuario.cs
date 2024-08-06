using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioUsuario
    {
        AccesoDatos datos = new AccesoDatos();

        public bool CambiarUsuarioYContrasena(string usuarioActual, string nuevaContrasena, string nuevoUsuario)
        {
            int filasAfectadas = datos.ActualizarUsuarioYContrasena(usuarioActual, nuevaContrasena, nuevoUsuario);
            return filasAfectadas > 0;
        }
    }
}
