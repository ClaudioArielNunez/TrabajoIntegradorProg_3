using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatosEspecialidades
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerEspecialidades()
        {
            DataTable tabla = datos.ObtenerTabla("Especialidades", "Select * from Especialidades");
            return tabla;
        }
    }
}
