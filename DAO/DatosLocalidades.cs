using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatosLocalidades
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable ObtenerLocalidades()
        {
            DataTable tabla = datos.ObtenerTabla("Localidades", "Select * from Localidades");
            return tabla;
        }
        public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            string consulta = $"SELECT ID_Localidad, ID_Provincia, Nombre FROM Localidades WHERE ID_Provincia = {idProvincia}";
            return datos.ObtenerTabla("Localidades", consulta);
        }
    }
}
