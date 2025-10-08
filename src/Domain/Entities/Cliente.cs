using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CUIT { get; set; } 
        public string  Nombre { get; set; }
        public string Apellido { get; set; }  
        public string Telefono {  get; set; }
        public Domicilio Domicilio{ get; set; }
        public CtaCte CtaCte { get; set; }
        public DateTime Fecha { get; set; }

    }
}
