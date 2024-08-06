using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int idLocalidad;
        private int idProvincia;
        private string nombre;

        public Localidad()
        {

        }
        public Localidad(int idLocalidad, int idProvincia, string nombre)
        {
            this.idLocalidad = idLocalidad;
            this.idProvincia = idProvincia;
            this.nombre = nombre;
        }

        #region
        public int IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }
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
