using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movimiento
    {
        public int Id { get; set; } 
        public DateTime Fecha { get; set; }  
        public string Descripcion { get; set; }
        public decimal Haber { get; set; } 
        public decimal Debe { get; set; } 
        public int? CtaCteId { get; set; }  
    }
}