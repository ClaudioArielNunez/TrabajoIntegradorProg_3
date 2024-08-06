using DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NegocioPacientes
    {
        DatosPacientes datos = new DatosPacientes();
        public DataTable BuscarPaciente(int dni)
        {
            return datos.buscarPacienete(dni);
        }

        public int AgregarPaciente(Paciente nuevoPaciente)
        {
            int filas = datos.AgregarPaciente(nuevoPaciente);
            return filas;
        }
        public DataTable ListarPacientes()
        {
            return datos.ListaDePacientes();
        }
        public DataTable BuscarPorApellido(string apellido)
        {
            return datos.BuscarPacientes(apellido);
        }
        public DataTable BuscarPorDNI(string dni)
        {
            return datos.BuscarDni(dni);
        }
        public DataTable FiltrarSexo(string sexo)
        {
            return datos.FiltrarSexo(sexo);
        }

        public void DeleteLogico(Paciente paciente)
        {
            datos.BorrarLogico(paciente);
        }

        public bool ActualizarPaciente(Paciente paciente)
        {
            return datos.ActualizarPacientes(paciente);
        }

        public DataTable BuscarPorId(string id_Paciente)
        {
            return datos.BuscarIdPaciente(id_Paciente);
        }
                

        public List<string> ListaDniPacientes()
        {
            return datos.ListaDniPaciente();
        }
    }
}
