using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movimiento
    {
        public string Id { get; set; }
        public DateTime fecha { get; set; }
        public string Descripcion {  get; set; }
        public float Haber { get; set; } 
        public float Debe {  get; set; }
    }
}
