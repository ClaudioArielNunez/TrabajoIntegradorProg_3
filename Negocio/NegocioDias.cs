using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class NegocioDias
    {
        public DataTable ListarDias()
        {
            DatosDias datos = new DatosDias();
            return datos.ObtenerDias();
        }
    }
}
