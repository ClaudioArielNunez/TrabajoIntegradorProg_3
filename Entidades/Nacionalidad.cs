using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nacionalidad
    {
        private int idNacionalidad;
        private string nacionalidad;

        public Nacionalidad()
        {

        }
        public Nacionalidad(int idNacionalidad, string nacionalidad)
        {
            this.idNacionalidad = idNacionalidad;
            this.nacionalidad = nacionalidad;
        }

        #region
        public int IdNacionalidad
        {
            get { return idNacionalidad; }
            set { idNacionalidad = value; }
        }

        public string NombreNacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }
        #endregion
    }
}
