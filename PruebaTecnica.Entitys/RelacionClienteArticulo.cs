using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entities
{
    public class RelacionClienteArticulo
    {
        public int RelacionClienteArticuloId { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
