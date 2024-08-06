using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class DatosProvincias
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerProvincias()
        {
            DataTable tabla = datos.ObtenerTabla("Provincias", "Select * from Provincias");
            return tabla;
        }
    }
}
