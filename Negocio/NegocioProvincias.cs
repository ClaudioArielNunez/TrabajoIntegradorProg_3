using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAO;
using System.Data;

namespace Negocio
{
    public class NegocioProvincias
    {
        public DataTable ListarProvincias()
        {
            DatosProvincias datos = new DatosProvincias();
            return datos.ObtenerProvincias();
        }
    }
}
