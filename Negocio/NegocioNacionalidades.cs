﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAO;
using System.Data;

namespace Negocio
{
    public class NegocioNacionalidades
    {
        public DataTable ListarNacionalidades()
        {
            DatosNacionalidades datos = new DatosNacionalidades();
            return datos.ObtenerNacionalidades();
        }
    }
}