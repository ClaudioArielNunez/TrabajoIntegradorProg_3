using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioLocalidades
    {
        DatosLocalidades datos = new DatosLocalidades();
        public DataTable ListarLocalidades()
        {
            return datos.ObtenerLocalidades();
        }
        public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            return datos.ObtenerLocalidadesPorProvincia(idProvincia);
        }
    }
}
