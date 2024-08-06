using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
namespace DAO
{
    public class DatosTurnos
    {
        AccesoDatos datos = new AccesoDatos();
        private SqlConnection cadenaConexion;

        public DataTable FiltrarTurno(int Legajo, string fecha)
        {

            return datos.ObtenerTabla("TurnoMedico", "select fecha_turno, ID_Horarios from TurnoMedico where Legajo = '" + Legajo + "' and fecha_turno = '" + fecha + "'");
        }


        public bool InsertarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametros(comando, turno);
            int filasInsertadas = datos.EjecutarStoredProcedure(comando, "spInsertarTurno");
            return filasInsertadas == 1 ? true : false;
        }


        private void ArmarParametros(SqlCommand comando, Turnos turno)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@ID_paciente", SqlDbType.Int);
            parametros.Value = turno.ID_paciente1;
            parametros = comando.Parameters.Add("@Legajo", SqlDbType.Int);
            parametros.Value = turno.Legajo1;
            parametros = comando.Parameters.Add("@ID_Dia", SqlDbType.Int);
            parametros.Value = turno.ID_Dia1;
            parametros = comando.Parameters.Add("@ID_Horarios", SqlDbType.Int);
            parametros.Value = turno.ID_Horarios1;
            parametros = comando.Parameters.Add("@fecha_turno", SqlDbType.DateTime);
            parametros.Value = turno.Fecha_turno;
            parametros = comando.Parameters.Add("@motivo_consulta", SqlDbType.VarChar,100);
            parametros.Value = turno.Motivo_consulta;
       
        }

        

        public DataTable TotalAsistenciasAusencias(DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta = @" SELECT SUM(CASE WHEN Paciente_Presente = 1 THEN 1 ELSE 0 END) AS Asistencias, 
                                        SUM(CASE WHEN Paciente_Presente = 0 THEN 1 ELSE 0 END) AS Ausencias 
                                 FROM TurnoMedico 
                                 WHERE  fecha_turno >= @FechaInicio AND fecha_turno < DATEADD(DAY, 1, @FechaFin)";

            SqlParameter[] parametros =
           {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin)
            };
             DataTable tabla = datos.ObtenerTablaConParametros("TurnoMedico", consulta, parametros);
            return tabla;
        }

        public bool ActualizarTurno(Turnos turno)
        {
            string consulta = "UPDATE TurnoMedico SET Paciente_Presente = '"+ turno.Paciente_presente + "', Observacion = '"+ turno.Observacion + "' WHERE ID_turno = "+ turno.ID_turno1;

            int filasInsertadas = datos.EjecutarConsulta(consulta);
            return filasInsertadas == 1;
        }

        public DataTable TurnosPorEspecialidad(DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta = 
                @"SELECT DISTINCT Especialidades.Nombre AS Especialidad,
                  SUM(CASE WHEN Medicos.ID_Especialidad = Especialidades.ID_Especialidad THEN 1 END) AS Cantidad
                  FROM TurnoMedico
                  INNER JOIN Medicos ON TurnoMedico.Legajo = Medicos.Legajo
                  INNER JOIN Especialidades ON Medicos.ID_Especialidad = Especialidades.ID_Especialidad
                  WHERE fecha_turno >= @FechaInicio AND fecha_turno < DATEADD(DAY, 1, @FechaFin)
                  GROUP BY Especialidades.Nombre";

            SqlParameter[] parametros =
            {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin)
            };
            DataTable tabla = datos.ObtenerTablaConParametros("TurnoMedico", consulta, parametros);
            return tabla;
        }

        public DataTable TurnosDelDiaPorMedico(int Legajo, DateTime Fecha)
        {
            string consulta =
                @"SELECT  ID_turno as Turno,CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "'AND tm.fecha_turno = '" + Fecha + "' AND p.Activo = 1 order by   h.ID_Horario asc";
            return datos.ObtenerTabla("TurnoMedico", consulta);

        }

        public DataTable TurnosPorApellido(int legajo, string apellido)
        {
            string consulta =
                @"SELECT  ID_turno as Turno,CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + legajo + "'AND p.Apellido LIKE '%" + apellido + "%' AND p.Activo = 1 order by   tm.fecha_turno DESC";
            return datos.ObtenerTabla("TurnoMedico", consulta);
        }

        public DataTable TurnosPorDNI(int Legajo, int dni)
        {
            string consulta =
                @"SELECT  ID_turno as Turno,CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "'AND p.DNI = '" + dni + "' AND p.Activo = 1 order by   tm.fecha_turno DESC";
            return datos.ObtenerTabla("TurnoMedico", consulta);
        }

        public DataTable TodosfiltrosTurnos (int Legajo, int mes , int asistencia)
        {

            string consulta=
                 @"SELECT  ID_turno as Turno,CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "'AND tm.Paciente_Presente = '" + asistencia + "' and  MONTH(tm.fecha_turno) = '"+ mes + "' AND p.Activo = 1 order by   tm.fecha_turno DESC";
            return datos.ObtenerTabla("TurnoMedico", consulta);
        }

        public DataTable FiltrarPorMES(int Legajo, int mes)
        {

            string consulta =
                 @"SELECT ID_turno as Turno, CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "' and  MONTH(tm.fecha_turno) = '" + mes + "' AND p.Activo = 1 order by   tm.fecha_turno DESC";
            return datos.ObtenerTabla("TurnoMedico", consulta);
        }


        public DataTable FiltrarPorAsistencia(int Legajo, int asistencia)
        {
            string consulta =
                 @"SELECT ID_turno as Turno, CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "'AND tm.Paciente_Presente = '" + asistencia + "' AND p.Activo = 1 order by   tm.fecha_turno DESC";
            return datos.ObtenerTabla("TurnoMedico", consulta);

        }
        public DataTable FiltrarPorMedico(int Legajo)
        {
            string consulta =
                @"SELECT  ID_turno as Turno,CONVERT(varchar, tm.fecha_turno, 23) AS Fecha, h.Hora_Turno AS Horario, p.Nombre AS Nombre, p.Apellido AS Apellido, 
                p.DNI AS DNI, tm.motivo_consulta AS Motivo, tm.Paciente_Presente AS Asistencia, tm.Observacion AS Observaciones
                FROM Pacientes AS p 
                INNER JOIN TurnoMedico AS tm ON tm.ID_paciente = p.ID_Paciente 
                INNER JOIN MedicosxDiasxHorarios AS mdh ON tm.Legajo = mdh.Legajo AND tm.ID_Dia = mdh.ID_Dia AND tm.ID_Horarios = mdh.ID_Horario 
                INNER JOIN DiasxHorarios AS dh ON dh.ID_Dia = mdh.ID_Dia AND dh.ID_Horario = mdh.ID_Horario 
                INNER JOIN Horarios AS h ON dh.ID_Horario = h.ID_Horario 
                WHERE tm.Legajo = '" + Legajo + "' AND p.Activo = 1  order by   tm.fecha_turno DESC"

                ;
            return datos.ObtenerTabla("TurnoMedico", consulta);
        }

    }
}

