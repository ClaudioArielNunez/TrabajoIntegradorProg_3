using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;


namespace Negocio
{
    public class NegocioMedicosxDiasxHorarios
    {
        DatosMedicosxDiasxHorarios datos = new DatosMedicosxDiasxHorarios();

        public DataTable FiltarHoraio(int Legajo, int dia)
        {
            return datos.FiltrarHorario(Legajo, dia);
        }
        public void AgregarDiasHorariosMedico(int legajo, int dia, int horarioInicio, int horarioFin)
        {
            datos.AgregarDiasHorariosMedico(legajo, dia, horarioInicio, horarioFin);
        }



    }
}
