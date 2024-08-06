using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int idProvincia;
        private string nombre;

        public Provincia()
        {

        }
        public Provincia(int idProvincia, string nombre)
        {
            this.idProvincia = idProvincia;
            this.nombre = nombre;
        }

        #region
        public int IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion
    }
}
