using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entities
{
    public class RelacionArticuloTienda
    {
        public int RelacionArticuloTiendaId { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
