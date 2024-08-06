using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatosNacionalidades
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerNacionalidades()
        {
            DataTable tabla = datos.ObtenerTabla("Nacionalidades", "SELECT ID_Nacionalidad, Nacionalidad FROM Nacionalidades");
            return tabla;
        }
    }
}
