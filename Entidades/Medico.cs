using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private int legajo;
        private string dni;
        private string nombre;
        private string apellido;
        private char sexo;
        private int nacionalidad;
        private DateTime fechaNacimiento;
        private string direccion;
        private string correoElectronico;
        private string telefono;
        private int idLocalidad;
        private int idProvincia;
        private int idEspecialidad;
        private int idUsuario; //por defecto 2
        private bool activo; //por defecto 1
        private string username; //tiene apellido por defecto
        private string password; //tiene 1234 por defecto

        public Medico()
        {

        }
        public Medico(int legajo, string dni, string nombre, string apellido, char sexo, int nacionalidad, DateTime fechaNacimiento, string direccion, string correoElectronico, string telefono, int idLocalidad, int idProvincia, int idEspecialidad, int idUsuario, bool activo, string username = null, string password = null)
        {
            this.legajo = legajo; 
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.correoElectronico = correoElectronico;
            this.telefono = telefono;
            this.idLocalidad = idLocalidad;
            this.idProvincia = idProvincia;
            this.idEspecialidad = idEspecialidad;
            this.idUsuario = idUsuario;
            this.activo = activo;
            this.username = username;
            this.password = password;
        }

        #region Getters Setters
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
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
            get { return nacionalidad; }
            set { nacionalidad = value; }
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

        public int IDEspecialidad
        {
            get { return idEspecialidad; }
            set { idEspecialidad = value; }
        }

        public int IDUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion
    }
}
