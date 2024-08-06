using System;

namespace Entidades
{
    public class Turnos
    {
        private int ID_turno;
        private int ID_paciente;
        private int Legajo;
        private int ID_Dia;
        private int ID_Horarios;
        private DateTime fecha_turno;
        private string motivo_consulta;
        private bool paciente_presente;
        private string observacion;

        public Turnos()
        {
        }

        public Turnos(int ID_paciente, int Legajo, int ID_Dia, int ID_Horarios, DateTime fecha_turno, string motivo_consulta)
        {
            this.ID_paciente1 = ID_paciente;
            this.Legajo1 = Legajo;
            this.ID_Dia1 = ID_Dia;
            this.ID_Horarios1 = ID_Horarios;
            this.Fecha_turno = fecha_turno;
            this.motivo_consulta = motivo_consulta;

        }

        public int ID_paciente1 { get => ID_paciente; set => ID_paciente = value; }
        public int Legajo1 { get => Legajo; set => Legajo = value; }
        public int ID_Dia1 { get => ID_Dia; set => ID_Dia = value; }
        public int ID_Horarios1 { get => ID_Horarios; set => ID_Horarios = value; }
        public DateTime Fecha_turno { get => fecha_turno; set => fecha_turno = value; }
        public string Motivo_consulta { get => motivo_consulta; set => motivo_consulta = value; }
        public bool Paciente_presente { get => paciente_presente; set => paciente_presente = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int ID_turno1 { get => ID_turno; set => ID_turno = value; }
    }
}
