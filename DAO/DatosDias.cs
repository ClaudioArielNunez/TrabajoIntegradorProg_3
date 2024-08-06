using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatosDias
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerDias()
        {
            DataTable tabla = datos.ObtenerTabla("Dias", "Select * from Dias");
            return tabla;
        }
    }
}
