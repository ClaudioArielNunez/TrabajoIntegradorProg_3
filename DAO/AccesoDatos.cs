using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class AccesoDatos
    {
        string cadenaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=TPI_Clinica; Integrated Security=True";
        public AccesoDatos()
        {

        }

        private SqlConnection Conectar()
        {
            SqlConnection conect = new SqlConnection(cadenaConexion);
            try
            {
                conect.Open();
                return conect;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(string consulta, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consulta, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal int ObtenerTipoUser(string consulta)
        {
            int tipoUser = 0;
            DataSet ds = new DataSet();
            SqlConnection con = Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    tipoUser = (int)dr[0];
                }
            }
            con.Close();
            dr.Close();
            return tipoUser;
        }

        public string ObtenerUsuario(string consultaSql)
        {
            string nombreCompleto = "";
            DataSet ds = new DataSet();
            SqlConnection Conect = Conectar();
            SqlCommand cmd = new SqlCommand(consultaSql, Conect);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    nombreCompleto = dr[0].ToString()+" "+dr[1].ToString();
                }
            }
            Conect.Close();
            dr.Close();
            return nombreCompleto;
        }

        public int obtenerLegajodelUsuario(string consultaSql)
        {
            int legajo = 0;
            DataSet ds = new DataSet();
            SqlConnection Conect = Conectar();
            SqlCommand cmd = new SqlCommand(consultaSql, Conect);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    legajo = dr.GetInt32(dr.GetOrdinal("Legajo"));
                }
            }
            Conect.Close();
            dr.Close();

            return legajo;
        }
               
        
        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conect = Conectar();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conect);
            adp.Fill(ds, NombreTabla);
            Conect.Close();
            return ds.Tables[NombreTabla];
        }

       public DataTable ObtenerTablaConParametros(string NombreTabla, string consultaSQL, SqlParameter[] parametros = null)
        {
            DataSet ds = new DataSet();
            SqlConnection con = Conectar();
            SqlDataAdapter adp = ObtenerAdaptador(consultaSQL, con);
            adp.SelectCommand = new SqlCommand(consultaSQL, con);

                if (parametros != null)
                {
                    adp.SelectCommand.Parameters.AddRange(parametros);
                    adp.Fill(ds, NombreTabla);
                    con.Close();
                    return ds.Tables[NombreTabla];
                }
                try
                {
                    adp.Fill(ds, NombreTabla);
                    con.Close();
                    return ds.Tables[NombreTabla];
                }
                catch (Exception ex)
                {
                     return null;
                }
        }


        public int EjecutarStoredProcedure(SqlCommand comando, string StoredProcedure)
        {
            int filas;
            SqlConnection con = Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;
            filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas;
        }

        public int EjecutarConsulta(string consultaSQL)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, con);
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas;
        }

        public int ActualizarUsuarioYContrasena(string usuarioActual, string nuevaContrasena, string nuevoUsuario)
        {
            string consulta = "UPDATE Medicos SET username = @nuevoUsuario, password = @nuevaContrasena WHERE username = @usuarioActual";
            SqlConnection con = Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@nuevoUsuario", nuevoUsuario);
            cmd.Parameters.AddWithValue("@nuevaContrasena", nuevaContrasena);
            cmd.Parameters.AddWithValue("@usuarioActual", usuarioActual);
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas;
        }
    }
}
