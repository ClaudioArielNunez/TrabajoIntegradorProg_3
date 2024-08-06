using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioEspecialidades
    {
        public DataTable ListarEspecialidades()
        {
            DatosEspecialidades datos = new DatosEspecialidades();
            return datos.ObtenerEspecialidades();
        }
    }
}
