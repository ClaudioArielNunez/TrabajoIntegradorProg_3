using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatosHorarios
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerHorarios()
        {
            DataTable tabla = datos.ObtenerTabla("Horarios", "Select * from Horarios");
            return tabla;
        }
    }
}
