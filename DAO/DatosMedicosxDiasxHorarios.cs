using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAO
{
    public class DatosMedicosxDiasxHorarios
    {
        AccesoDatos datos = new AccesoDatos();

        public DataTable FiltrarHorario(int Legajo, int Dia)
        {
            string consultaFiltro = "select h.Hora_Turno, h.ID_Horario from MedicosxDiasxHorarios as mdh inner join " +
                                   $" DiasxHorarios as dh on mdh.ID_Dia = dh.ID_Dia and mdh.ID_Horario = dh.ID_Horario " +
                                   $"inner join Horarios as h on dh.ID_Horario = h.ID_Horario " +
                                   $"where mdh.Legajo = '" + Legajo + "'  and mdh.ID_Dia = '" + Dia + "'";
            DataTable tabla = datos.ObtenerTabla("MedicosxDiasxHorarios", consultaFiltro);
            return tabla;

        }

        public void AgregarDiasHorariosMedico(int legajo, int dia, int horarioInicio, int horarioFin)
        {
            for (int horario = horarioInicio; horario <= horarioFin-1; horario++)
            {
                string consulta = $"INSERT INTO MedicosxDiasxHorarios (Legajo, ID_Dia, ID_Horario) VALUES ({legajo}, {dia}, {horario})";
                datos.EjecutarConsulta(consulta);
            }
        }
    }
}
