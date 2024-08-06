using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DatosMedicos
    {
        AccesoDatos datos = new AccesoDatos();
        public string BuscarLoginADMIN(string username, string password)
        {

            string consulta = "SELECT Nombre, Apellido FROM administradores WHERE username = '" + username + "' AND password = '" + password + "' AND ID_Usuario = 1";
            return datos.ObtenerUsuario(consulta);
        }
        public object BuscarLoginMedico(string username, string password)
        {
            string consulta = "SELECT Nombre, Apellido FROM MEDICOS WHERE username = '" + username + "' AND password = '" + password + "' AND ID_Usuario = 2";
            return datos.ObtenerUsuario(consulta);
        }

        public int BuscarLoginMedicoLegajo(string username, string password)
        {
            string consulta = "SELECT Legajo FROM MEDICOS WHERE username = '" + username + "' AND password = '" + password + "' AND ID_Usuario = 2";
            return datos.obtenerLegajodelUsuario(consulta);
        }

        public int BuscarTipoAdmin(string username, string password)
        {            
            string consulta = "select ID_Usuario from Administradores where username = '" +username+"' AND password = '"+ password +"'";
            return datos.ObtenerTipoUser(consulta);
        }
        public object BuscarTipoMed(string username, string password)
        {
            string consulta = "select ID_Usuario from MEDICOS where username = '" + username + "' AND password = '" + password + "'";
            return datos.ObtenerTipoUser(consulta);
        }

        public int AgregarMedico(string nombre, string apellido, string dni, string sexo, string nacionalidad, string fechaNacimiento, string direccion, string localidad, string provincia, string email, string telefono, string especialidad)
        {
            try
            {
                string consulta = $"INSERT INTO Medicos (Nombre, Apellido, DNI, Sexo, ID_Nacionalidad, Fecha_Nacimiento, Direccion, ID_Localidad, ID_Provincia, Correo_Electronico, Telefono, ID_Especialidad) " +
                                  $"VALUES ('{nombre}', '{apellido}', '{dni}', '{sexo}', '{nacionalidad}', '{fechaNacimiento}', '{direccion}', '{localidad}', '{provincia}', '{email}', '{telefono}', '{especialidad}')";

                datos.EjecutarConsulta(consulta);

                // Recuperar el Legajo recién agregado segun el DNI (suponiendo que es único)
                string consultaLegajo = $"SELECT Legajo FROM Medicos WHERE DNI = '{dni}'";
                DataTable dtLegajo = datos.ObtenerTabla("Medicos", consultaLegajo);

                if (dtLegajo.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtLegajo.Rows[0]["Legajo"]);
                }
                else
                {
                    throw new Exception("No se pudo recuperar el legajo del médico.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el médico: " + ex.Message);
            }
        }

        public void BorrarLogico(Medico medico)
        {
            string consultaDeleteLogica = "Update Medicos SET Activo = 0 WHERE LEGAJO = " + medico.Legajo;
            DataTable tabla = datos.ObtenerTabla("Medicos", consultaDeleteLogica);
        }

        public bool ActualizarMedicos(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametros(comando, medico);
            int filasInsertadas = datos.EjecutarStoredProcedure(comando, "Sp_ActualizarMedico");
            return filasInsertadas == 1 ? true : false;
        }

        public List<string> ListaDniMedicos()
        {
            List<string> lista = new List<string>();
            string consulta = "SELECT DNI FROM Medicos";
            DataTable tabla = datos.ObtenerTabla("Medicos", consulta);
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(fila["DNI"].ToString());
            }
            return lista;
        }

        private void ArmarParametros(SqlCommand comando, Medico medico)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@Legajo", SqlDbType.Int);
            parametros.Value = medico.Legajo;
            parametros = comando.Parameters.Add("@DNI", SqlDbType.VarChar,8);
            parametros.Value = medico.DNI;
            parametros = comando.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            parametros.Value = medico.Nombre;
            parametros = comando.Parameters.Add("@apellido", SqlDbType.VarChar, 50);
            parametros.Value = medico.Apellido;
            parametros = comando.Parameters.Add("@sexo", SqlDbType.Char);
            parametros.Value = medico.Sexo;
            parametros = comando.Parameters.Add("@nacionalidad", SqlDbType.Int);
            parametros.Value = medico.Nacionalidad;
            parametros = comando.Parameters.Add("@especialidad", SqlDbType.Int);
            parametros.Value = medico.IDEspecialidad;
            parametros = comando.Parameters.Add("@fecha", SqlDbType.DateTime);
            parametros.Value = medico.FechaNacimiento;
            parametros = comando.Parameters.Add("@direccion", SqlDbType.VarChar, 100);
            parametros.Value = medico.Direccion;
            parametros = comando.Parameters.Add("@localidad", SqlDbType.Int);
            parametros.Value = medico.IDLocalidad;
            parametros = comando.Parameters.Add("@provincia", SqlDbType.Int);
            parametros.Value = medico.IDProvincia;
            parametros = comando.Parameters.Add("@correo", SqlDbType.VarChar, 100);
            parametros.Value = medico.CorreoElectronico;
            parametros = comando.Parameters.Add("@telefono", SqlDbType.VarChar, 50);
            parametros.Value = medico.Telefono;
        }

        public DataTable BuscarIdMedico(string id_Medico)
        {
            string consulta = $"SELECT Legajo,DNI,M.Nombre, Apellido,Sexo,N.Nacionalidad AS Nacionalidad,E.Nombre as Especialidad," +
                              $"Fecha_Nacimiento,Direccion,L.Nombre AS Localidad,P.Nombre AS Provincia, Correo_Electronico, " +
                              $"Telefono FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad " +
                              $"INNER JOIN Localidades AS L ON M.ID_Localidad = L.ID_Localidad INNER JOIN Provincias AS P" +
                              $" ON M.ID_Provincia = P.ID_Provincia INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = M.ID_Nacionalidad" +
                              $" WHERE Activo = 1 AND Legajo = " + id_Medico;
            DataTable tabla = datos.ObtenerTabla("Medicos", consulta);
            return tabla;
        }
        public DataTable ListaDeMedicos()//
        {
            string consulta = $"SELECT Legajo,DNI,M.Nombre, Apellido,Sexo,N.Nacionalidad AS Nacionalidad,E.Nombre as Especialidad," +
                              $"Fecha_Nacimiento,Direccion,L.Nombre AS Localidad,P.Nombre AS Provincia, Correo_Electronico, " +
                              $"Telefono FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad " +
                              $"INNER JOIN Localidades AS L ON M.ID_Localidad = L.ID_Localidad INNER JOIN Provincias AS P" +
                              $" ON M.ID_Provincia = P.ID_Provincia INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = M.ID_Nacionalidad  WHERE Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Medicos", consulta);
            return tabla;
        }

        public DataTable BuscarMedicos(string apellido)
        {
            string consultaBusqueda = $"SELECT DNI,M.Nombre, Apellido,Sexo,N.Nacionalidad AS Nacionalidad,E.Nombre as Especialidad," +
                                      $"Fecha_Nacimiento,Direccion,L.Nombre AS Localidad,P.Nombre AS Provincia, Correo_Electronico, " +
                                      $"Telefono FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad " +
                                      $"INNER JOIN Localidades AS L ON M.ID_Localidad = L.ID_Localidad INNER JOIN Provincias AS P" +
                                      $" ON M.ID_Provincia = P.ID_Provincia INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = M.ID_Nacionalidad" +
                                      $" WHERE M.Apellido LIKE '%" + apellido + "%' AND M.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Medicos", consultaBusqueda);
            return tabla;
        }

        public DataTable BuscarDni(string dni)
        {
            string consultaBusqueda = $"SELECT DNI,M.Nombre, Apellido,Sexo,N.Nacionalidad AS Nacionalidad,E.Nombre as Especialidad," +
                                      $"Fecha_Nacimiento,Direccion,L.Nombre AS Localidad,P.Nombre AS Provincia, Correo_Electronico, " +
                                      $"Telefono FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad " +
                                      $"INNER JOIN Localidades AS L ON M.ID_Localidad = L.ID_Localidad INNER JOIN Provincias AS P" +
                                      $" ON M.ID_Provincia = P.ID_Provincia INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = M.ID_Nacionalidad" +
                                      $" WHERE M.DNI = '" + dni + "' AND M.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Medicos", consultaBusqueda);
            return tabla;
        }

        public DataTable FiltrarEspec(string especialidad)
        {
            string consultaFiltro = $"SELECT DNI,M.Nombre, Apellido,Sexo,N.Nacionalidad AS Nacionalidad,E.Nombre as Especialidad," +
                              $"Fecha_Nacimiento,Direccion,L.Nombre AS Localidad,P.Nombre AS Provincia, Correo_Electronico, " +
                              $"Telefono FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad " +
                              $"INNER JOIN Localidades AS L ON M.ID_Localidad = L.ID_Localidad INNER JOIN Provincias AS P" +
                              $" ON M.ID_Provincia = P.ID_Provincia INNER JOIN Nacionalidades AS N ON N.ID_Nacionalidad = M.ID_Nacionalidad" +
                              $" WHERE E.Nombre = '" + especialidad + "' AND M.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Medicos", consultaFiltro);
            return tabla;
        }

        public DataTable FiltrarDiasTrabajo(int legajo)
        {
            string consultaFiltro = " SELECT d.Dia FROM MedicosxDiasxHorarios as mdh inner join DiasxHorarios as dh on mdh.ID_Dia = dh.ID_Dia and " +
                                   $"mdh.ID_Horario = dh.ID_Horario inner join dias as d on d.ID_Dia = dh.ID_Dia WHERE mdh.Legajo = " + legajo + "";
            DataTable tabla = datos.ObtenerTabla("MedicosxDiasxHorarios", consultaFiltro);
            return tabla;
        }

        public DataTable RecibirNombyLeg(string especialidad)
        {
            string consultaFiltro = "SELECT Legajo,M.Nombre FROM MEDICOS AS M INNER JOIN Especialidades AS E ON M.ID_Especialidad = E.ID_Especialidad" +
                                   $" WHERE E.Nombre ='" + especialidad + "' AND M.Activo = 1";
            DataTable tabla = datos.ObtenerTabla("Medicos", consultaFiltro);
            return tabla;
        }


    }
}