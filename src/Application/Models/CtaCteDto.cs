using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CtaCteDto
    {
        public int Id { get; set; }
        public List<MovimientoDto> Movimientos { get; set; } = new();
    }
}
