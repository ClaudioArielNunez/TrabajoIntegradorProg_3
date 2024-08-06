using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private int idPaciente;
        private string dni;
        private string nombre;
        private string apellido;
        private char sexo;
        private int idNacionalidad;
        private DateTime fechaNacimiento;
        private string direccion;
        private string correoElectronico;
        private string telefono;
        private int idLocalidad;
        private int idProvincia;      
        private bool activo; //por defecto 1

        public Paciente()
        {

        }
        public Paciente(int idPaciente, string dni, string nombre, string apellido, char sexo, int idNacionalidad, DateTime fechaNacimiento, string direccion, string correoElectronico, string telefono, int idLocalidad, int idProvincia, bool activo)
        {
            this.idPaciente = idPaciente;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.idNacionalidad = idNacionalidad;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.correoElectronico = correoElectronico;
            this.telefono = telefono;
            this.idLocalidad = idLocalidad;
            this.idProvincia = idProvincia;
            this.activo = activo;
        }

            #region Getters Setters
        public int IDPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int Nacionalidad
        {
            get { return idNacionalidad; }
            set { idNacionalidad = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int IDLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }

        public int IDProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }      
        #endregion

    }
}

