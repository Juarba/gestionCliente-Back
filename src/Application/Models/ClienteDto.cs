﻿using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }

        // Relaciones
        public DomicilioDto Domicilio { get; set; }
        public CtaCteDto CtaCte { get; set; }
    }
}
