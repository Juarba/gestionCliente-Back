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
        public int CUIT { get; set; } 
        public string  Nombre { get; set; }
        public string Apellido { get; set; }  
        public string Telefono {  get; set; }
        public Direccion Direccion{ get; set; }
        public DateTime Fecha { get; set; }

    }
}
