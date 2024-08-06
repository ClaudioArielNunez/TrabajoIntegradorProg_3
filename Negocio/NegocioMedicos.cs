using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using Entidades;

namespace Negocio
{
    public class NegocioMedicos
    {
        private DatosMedicos datos = new DatosMedicos();
        private DatosMedicosxDiasxHorarios datosMDH = new DatosMedicosxDiasxHorarios();
        public string AccesoAlSistemaADMIN(string username,string password )
        {
           return datos.BuscarLoginADMIN(username,password);
        }
        public int AccesoTipoUserAdmin(string username, string password)
        {
            return datos.BuscarTipoAdmin(username, password);
        }
        public object AccesoTipoUserMed(string username, string password)
        {
            return datos.BuscarTipoMed(username, password);
        }

        public object AccesoAlSistemaMedico(string username, string password)
        {
            return datos.BuscarLoginMedico(username, password);
        }

        public int AccesoAlSistemaMedicoLegajo(string username, string password)
        {
            return datos.BuscarLoginMedicoLegajo(username, password);
        }

        public int AgregarMedico(string nombre, string apellido, string dni, string sexo, string nacionalidad, string fechaNacimiento, string direccion, string localidad, string provincia, string email, string telefono, string especialidad/*, int diasSelec, int horarioInicio, int horarioFin*/)
        {
            //manda los parametro que recibio para medico y me devuelve el legajo del medico recien agregado
            int legajo = datos.AgregarMedico(nombre, apellido, dni, sexo, nacionalidad, fechaNacimiento, direccion, localidad, provincia, email, telefono, especialidad);

            return legajo;
        }
               

        public DataTable ListarMedicos()
        {
            return datos.ListaDeMedicos();
        }
        public DataTable BuscarPorApellido(string apellido)
        {
            return datos.BuscarMedicos(apellido);
        }


        public void DeleteLogico(Medico medico)
        {
            datos.BorrarLogico(medico);
        }

        public DataTable BuscarPorDNI(string dni)
        {
            return datos.BuscarDni(dni);
        }
        public DataTable FiltrarEspecialidad(string especialidad)
        {
            return datos.FiltrarEspec(especialidad);
        }

        public bool ActualizarMedico(Medico medico)
        {
            return datos.ActualizarMedicos(medico);
        }

        public DataTable BuscarPorId(string id_Medico)
        {
            return datos.BuscarIdMedico(id_Medico);
        }

        public DataTable FiltrarDiasTraajo(int Legajo)
        {
            return datos.FiltrarDiasTrabajo(Legajo);
        }

        public DataTable RecibirLegyNomb(string especialidad)
        {
            return datos.RecibirNombyLeg(especialidad);
        }

        public List<string> ListarDni()
        {
            return datos.ListaDniMedicos();
        }
    }
}