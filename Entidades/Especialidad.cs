using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        private int idEspecialidad;
        private string nombre;

        public Especialidad()
        {

        }
        public Especialidad(int idEspecialidad, string nombre)
        {
            this.idEspecialidad = idEspecialidad;
            this.nombre = nombre;
        }

        #region
        public int IdEspecialidad
        {
            get { return idEspecialidad; }
            set { idEspecialidad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion
    }
}
