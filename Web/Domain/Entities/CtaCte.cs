using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CtaCte
    {
        public int Id { get; set; }
        
        public List<Movimiento> Movimientos { get; set; }
        
        
    }
}
