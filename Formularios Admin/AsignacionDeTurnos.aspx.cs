using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_18_PR3_v1.Formularios_Admin
{
    public partial class AsignacionDeTurnos : System.Web.UI.Page
    {
        NegocioEspecialidades negEsp = new NegocioEspecialidades();
        NegocioMedicos negMed = new NegocioMedicos();
        NegocioMedicosxDiasxHorarios negMDH = new NegocioMedicosxDiasxHorarios();
        NegocioTurnos negTurnos = new NegocioTurnos();
        NegocioPacientes negPacientes = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["NombreUsuario"].ToString() != null )
                {
                    if (int.Parse(Session["TipoUsuario"].ToString()) == 1)
                    {
                        lbNombreUsuario.Text = Session["NombreUsuario"].ToString();
                        ///carga Especialidad
                        CargarEspecialidad();
                    }
                    else
                    {                        
                        Response.Redirect("~/Login.aspx");
                    }
                }                                
            }
        }




        ///carga Medicos
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidadSeleccionada = ddlEspecialidad.SelectedItem.Text;
            if (especialidadSeleccionada != "--Seleccione--")
            {    // al cambiar de Medico se vuelve a resetear  el horario
                ddlHorario.Items.Clear();
                ddlHorario.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));

                CargarMedicos(especialidadSeleccionada);
            }
            else
            {

                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
            }

        }


        private void CargarEspecialidad()
        {
            bool emptyList = true;
            foreach (DataRow item in negEsp.ListarEspecialidades().Rows)
            {
                if (emptyList)
                {
                    ddlMedico.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
                    ddlEspecialidad.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
                    ddlHorario.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
                    emptyList = false;
                }
                ddlEspecialidad.Items.Add(item["Nombre"].ToString());
            }
        }

        private void CargarMedicos(string especialidad)
        {
            ddlMedico.Items.Clear();
            bool emptyList = true;
            foreach (DataRow item in negMed.RecibirLegyNomb(especialidad).Rows)
            {
                if (emptyList)
                {
                    ddlMedico.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
                    emptyList = false;
                }
                ddlMedico.Items.Add(new ListItem(item["Nombre"].ToString(), item["Legajo"].ToString()));

            }

        }

        ///carga los dias disponibles en el calendario
        protected void CalDia_DayRender(object sender, DayRenderEventArgs e)
        {
            // Desactivar todos los días por defecto
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;

            // Desactivar días anteriores al día actual y el dia actual
            if (e.Day.Date <= DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                return; // Salir del método para no seguir procesando
            }

            // Asegurarse de que haya un médico seleccionado
            if (ddlMedico.SelectedItem.Value != "--Seleccione--")
            {
                int Legajo;
                int.TryParse(ddlMedico.SelectedItem.Value, out Legajo);

                // Obtener el DataTable con los días de trabajo del médico seleccionado
                DataTable dtDiasTrabajo = negMed.FiltrarDiasTraajo(Legajo);

                // Iterar sobre las filas del DataTable y activar los días de trabajo
                foreach (DataRow row in dtDiasTrabajo.Rows)
                {
                    // Obtener el día de la semana desde la fila del DataTable
                    string diaString = row["Dia"].ToString();

                    // Convertir el día de la semana a DayOfWeek
                    DayOfWeek diaSemana = ConvertirDiaStringADayOfWeek(diaString);

                    // Comparar con el DayOfWeek del día actual en el calendario
                    if (e.Day.Date.DayOfWeek == diaSemana)
                    {
                        e.Day.IsSelectable = true; // Habilita el día en el calendario si coincide
                        e.Cell.ForeColor = System.Drawing.Color.Black; // Cambia el color opcionalmente
                        break; // Salir del bucle una vez que se haya encontrado coincidencia
                    }
                }

            }
        }


        private DayOfWeek ConvertirDiaStringADayOfWeek(string diaString)
        {
            switch (diaString.ToLower())
            {
                case "domingo":
                    return DayOfWeek.Sunday;
                case "lunes":
                    return DayOfWeek.Monday;
                case "martes":
                    return DayOfWeek.Tuesday;
                case "miercoles":
                    return DayOfWeek.Wednesday;
                case "jueves":
                    return DayOfWeek.Thursday;
                case "viernes":
                    return DayOfWeek.Friday;
                case "sabado":
                    return DayOfWeek.Saturday;
                default:
                    throw new ArgumentException("El día proporcionado no es válido.");
            }
        }


        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ///carga los Horarios
        protected void CalDia_SelectionChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada
            DateTime fechaSeleccionada = CalDia.SelectedDate;

            // Obtener el ID del día de la semana  
            int nombreDia = ObtenerID_Dia(fechaSeleccionada.DayOfWeek);

            int Legajo = int.Parse(ddlMedico.SelectedItem.Value);

            ddlHorario.Items.Clear();
            bool hayElementos = false;
            bool emptyList = true;
            //itera entre las horas de trabajo
            foreach (DataRow item in negMDH.FiltarHoraio(Legajo, nombreDia).Rows)
            {
                if (emptyList)
                {
                    ddlHorario.Items.Add(new ListItem("--Seleccione--", "--Seleccione--"));
                    emptyList = false;
                }
                bool emptyList2 = true;

                //itera entre los horarios de los turnos en cierta fecha
                foreach (DataRow item2 in negTurnos.filtrarTurnos(Legajo, fechaSeleccionada.ToString("yyyy-MM-dd")).Rows)
                {
                    //compara los horarios de los turnos ya entregados y los horarios de trabajo del medico
                    if (item["ID_Horario"].ToString() == item2["ID_Horarios"].ToString())
                    {
                        emptyList2 = false;
                    }
                }
                // si el horario del trabajo no tiene un turno ya reservado se mostrara ese horario en el ddlHorario
                if (emptyList2)
                {
                    ddlHorario.Items.Add(new ListItem(item["Hora_Turno"].ToString(), item["ID_Horario"].ToString()));
                    hayElementos = true;
                }


            }
            if (!hayElementos)
            {
                lblMensaje.Text = "No hay horarios disponibles ese día";
            }
            else
            {
                lblMensaje.Text = ""; // Limpia el mensaje en caso de que haya elementos
            }
        }

        ///a los dias de la semana le doy su id
        private int ObtenerID_Dia(DayOfWeek diaSemana)
        {
            switch (diaSemana)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 7;
                default:
                    return 0;
            }
        }

        protected void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            DataTable paciente = negPacientes.BuscarPaciente(int.Parse(tbPaciente.Text));

            if (paciente == null || paciente.Rows.Count == 0)
            {

                lblMensaje.Text = "*No se encontró el paciente.Por favor, regístrelo antes de continuar.*";

                return;
            }

            int ID_Paciente = Convert.ToInt32(paciente.Rows[0]["ID_Paciente"]);
            int Legajo = int.Parse(ddlMedico.SelectedItem.Value);
            DateTime fechaSeleccionada = CalDia.SelectedDate;
            int ID_Dia = ObtenerID_Dia(fechaSeleccionada.DayOfWeek);
            int ID_Horarios = int.Parse(ddlHorario.SelectedValue);
            DateTime fecha_turno = CalDia.SelectedDate;
            string motivo_Consulta = txtMotivoConsulta.Text;
            //cargo una clase Turno con los datos para guardarlo en la base de datos
            Turnos turno = new Turnos();
            turno.ID_paciente1 = ID_Paciente;
            turno.Legajo1 = Legajo;
            turno.ID_Dia1 = ID_Dia;
            turno.ID_Horarios1 = ID_Horarios;
            turno.Fecha_turno = fecha_turno;
            turno.Motivo_consulta = motivo_Consulta;

            if (negTurnos.InsertarTurno(turno))
            {
                lblMensaje.Text = "TURNO GUARDADO";
            }
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            tbPaciente.Text = "";
            ddlHorario.Items.Clear();
            ddlHorario.Items.Add(new ListItem("--Seleccione--", string.Empty));
            txtMotivoConsulta.Text = "";

        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = "default";
            Session["TipoUsuario"] = 2; //por defecto es un usuario medico
            Response.Redirect("~/LogIn.aspx");
        }
    }
}