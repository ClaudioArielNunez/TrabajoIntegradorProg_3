using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioHorarios
    {
        public DataTable ListarHorarios()
        {
            DatosHorarios datos = new DatosHorarios();
            return datos.ObtenerHorarios();
        }
    }
}
