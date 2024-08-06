using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades;


namespace Negocio
{
    public class NegocioTurnos
    { DatosTurnos datos = new DatosTurnos();
        public DataTable filtrarTurnos(int legajo, string fecha)
        {
           
            return datos.FiltrarTurno(legajo, fecha);
        }

        public bool InsertarTurno(Turnos turno)
        {
            return datos.InsertarTurno(turno);
        }
        public DataTable TotalAsistenciasAusencias(DateTime fechaInicio, DateTime fechaFin)
        {
            return datos.TotalAsistenciasAusencias(fechaInicio, fechaFin);
        }

        public DataTable TurnosPorEspecialidad(DateTime fechaInicio, DateTime fechaFin)
        {
            return datos.TurnosPorEspecialidad(fechaInicio, fechaFin);
        }

        public DataTable MostrarTurnosdelDIA(int Legajo, DateTime Fecha)
        {
            return datos.TurnosDelDiaPorMedico(Legajo, Fecha);
        }

        public  DataTable MostrarTurnosPorDNI(int legajo, int dni)
        {
            return datos.TurnosPorDNI(legajo, dni);
        }
        
        public DataTable MostrarTurnosPorApellido(int legajo, string apellido)
        {
            return datos.TurnosPorApellido(legajo, apellido);
        }
        public DataTable MostrarFiltrosTurnos(int legajo, int mes, int asistencia)
        {
            if (mes != 0 && asistencia != -1)
            {
                return datos.TodosfiltrosTurnos(legajo, mes, asistencia);
            }
            else if (mes != 0 && asistencia == -1)
            {
                return datos.FiltrarPorMES(legajo, mes);
            }
            else if (mes == 0 && asistencia != -1)
            {
                return datos.FiltrarPorAsistencia(legajo, asistencia);
            }
            else
            {
                return datos.FiltrarPorMedico(legajo);
            }    
        }

        public void ActualizarTurno(Turnos turno)
        {
            bool actualizado = datos.ActualizarTurno(turno);
        }
    }
}
