using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace DAO
{
    public class DatosPacientes
    {
        AccesoDatos datos = new AccesoDatos();
        public DataTable buscarPacienete(int dni)
        {
            DataTable tabla = datos.ObtenerTabla("Pacientes", "select ID_Paciente from Pacientes where Pacientes.DNI = '" + dni + "'");
            return tabla;
        }

        public int AgregarPaciente(Paciente nuevoPaciente)
        {
            int filas;
            filas = datos.EjecutarConsulta("INSERT INTO Pacientes(DNI, Nombre, Apellido, Sexo, ID_Nacionalidad, Fecha_Nacimiento, Direccion, Correo_Electronico, Telefono, ID_Localidad, ID_Provincia) " +
                                   "VALUES('" + nuevoPaciente.DNI + "', '" + nuevoPaciente.Nombre + "', '" + nuevoPaciente.Apellido + "', '" + nuevoPaciente.Sexo + "', " + nuevoPaciente.Nacionalidad + ", '" + nuevoPaciente.FechaNacimiento + "', '" + nuevoPaciente.Direccion + "', '" + nuevoPaciente.CorreoElectronico + "', '" + nuevoPaciente.Telefono + "', " + nuevoPaciente.IDLocalidad + ", " + nuevoPaciente.IDProvincia + ")");
            return filas;
        }

        public bool ActualizarPacientes(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametros(comando, paciente);
            int filasInsertadas = datos.EjecutarStoredProcedure(comando, "Sp_ActualizarPaciente");
            return filasInsertadas == 1 ? true : false;
        }

        public List<string> ListaDniPaciente()
        {
            List<string> lista = new List<string>();
            string consulta = "select DNI from Pacientes";
            DataTable tabla = datos.ObtenerTabla("Pacientes", consulta);
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(fila["DNI"].ToString());
            }
            return lista;
        }

        public DataTable BuscarIdPaciente(string id_Paciente)
        {
            string consulta = $"SELECT ID_Paciente, DNI, P.Nombre, Apellido, Sexo, N.Nacionalidad AS Nacionalidad, Fecha_Nacimiento, Direccion, L.Nombre AS Localidad, Pr.Nombre AS Provincia, Correo_Electronico, Telefono " +
                              $"FROM PACIENTES AS P INNER JOIN Localidades AS L ON P.ID_Localidad = L.ID_Localidad " +
                              $"INNER JOIN Provincias AS Pr ON L.ID_Provincia = Pr.ID_Provincia " +
                              $"INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = P.ID_Nacionalidad WHERE Activo = 1 AND ID_Paciente = "+ id_Paciente;
            DataTable tabla = datos.ObtenerTabla("Pacientes", consulta);
            return tabla;
        }

        private void ArmarParametros(SqlCommand comando, Paciente paciente)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDPaciente", SqlDbType.Int);
            parametros.Value = paciente.IDPaciente;
            parametros = comando.Parameters.Add("@DNI", SqlDbType.VarChar, 8);
            parametros.Value = paciente.DNI;
            parametros = comando.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            parametros.Value = paciente.Nombre;
            parametros = comando.Parameters.Add("@apellido", SqlDbType.VarChar, 50);
            parametros.Value = paciente.Apellido;
            parametros = comando.Parameters.Add("@sexo", SqlDbType.Char);
            parametros.Value = paciente.Sexo;
            parametros = comando.Parameters.Add("@nacionalidad", SqlDbType.Int);
            parametros.Value = paciente.Nacionalidad;
            parametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            parametros.Value = paciente.FechaNacimiento;
            parametros = comando.Parameters.Add("@direccion", SqlDbType.VarChar, 100);
            parametros.Value = paciente.Direccion;
            parametros = comando.Parameters.Add("@localidad", SqlDbType.Int);
            parametros.Value = paciente.IDLocalidad;
            parametros = comando.Parameters.Add("@provincia", SqlDbType.Int);
            parametros.Value = paciente.IDProvincia;
            parametros = comando.Parameters.Add("@correo", SqlDbType.VarChar, 100);
            parametros.Value = paciente.CorreoElectronico;
            parametros = comando.Parameters.Add("@telefono", SqlDbType.VarChar, 50);
            parametros.Value = paciente.Telefono;
        }

        public void BorrarLogico(Paciente paciente)
        {
            string consultaDeleteLogica = "Update Pacientes SET Activo = 0 WHERE ID_Paciente = " + paciente.IDPaciente;
            DataTable tabla = datos.ObtenerTabla("Pacientes", consultaDeleteLogica);
        }

        public DataTable ListaDePacientes()
        {
            string consulta = $"SELECT ID_Paciente, DNI, P.Nombre, Apellido, Sexo, N.Nacionalidad AS Nacionalidad, Fecha_Nacimiento, Direccion, L.Nombre AS Localidad, Pr.Nombre AS Provincia, Correo_Electronico, Telefono " + 
                              $"FROM PACIENTES AS P INNER JOIN Localidades AS L ON P.ID_Localidad = L.ID_Localidad " +
                              $"INNER JOIN Provincias AS Pr ON L.ID_Provincia = Pr.ID_Provincia " + 
                              $"INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = P.ID_Nacionalidad WHERE Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Pacientes", consulta);
            return tabla;
        }

        public DataTable BuscarPacientes(string apellido)
        {
            string consultaBusqueda = $"SELECT DNI, P.Nombre, Apellido, Sexo, N.Nacionalidad AS Nacionalidad, Fecha_Nacimiento, Direccion, L.Nombre AS Localidad, Pr.Nombre AS Provincia, Correo_Electronico, Telefono " +
                              $"FROM PACIENTES AS P INNER JOIN Localidades AS L ON P.ID_Localidad = L.ID_Localidad " +
                              $"INNER JOIN Provincias AS Pr ON L.ID_Provincia = Pr.ID_Provincia " +
                              $"INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = P.ID_Nacionalidad" +
                                      $" WHERE P.Apellido LIKE '%" + apellido + "%' AND P.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Pacientes", consultaBusqueda);
            return tabla;
        }

        public DataTable BuscarDni(string dni)
        {
            string consultaBusqueda = $"SELECT DNI, P.Nombre, Apellido, Sexo, N.Nacionalidad AS Nacionalidad, Fecha_Nacimiento, Direccion, L.Nombre AS Localidad, Pr.Nombre AS Provincia, Correo_Electronico, Telefono " +
                                      $"FROM PACIENTES AS P INNER JOIN Localidades AS L ON P.ID_Localidad = L.ID_Localidad " +
                                      $"INNER JOIN Provincias AS Pr ON L.ID_Provincia = Pr.ID_Provincia " +
                                      $"INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = P.ID_Nacionalidad" +
                                      $" WHERE P.DNI = '" + dni + "' AND P.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Pacientes", consultaBusqueda);
            return tabla;
        }
        public DataTable FiltrarSexo(string sexo)
        {
            string consultaFiltro = $"SELECT DNI, P.Nombre, Apellido, Sexo, N.Nacionalidad AS Nacionalidad, Fecha_Nacimiento, Direccion, L.Nombre AS Localidad, Pr.Nombre AS Provincia, Correo_Electronico, Telefono " +
                                      $"FROM PACIENTES AS P INNER JOIN Localidades AS L ON P.ID_Localidad = L.ID_Localidad " +
                                      $"INNER JOIN Provincias AS Pr ON L.ID_Provincia = Pr.ID_Provincia " +
                                      $"INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = P.ID_Nacionalidad" +
                              $" WHERE Sexo = '" + sexo + "' AND P.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Pacientes", consultaFiltro);
            return tabla;
        }
      
    }
}
