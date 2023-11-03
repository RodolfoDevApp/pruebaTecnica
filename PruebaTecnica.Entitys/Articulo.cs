using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entities
{
    public class Articulo
    {
        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }

        // Relación con las Tiendas donde se encuentra el Artículo
        public ICollection<RelacionArticuloTienda>? TiendasDondeSeEncuentra { get; set; }

        // Relación con los Clientes que han comprado el Artículo
        public ICollection<RelacionClienteArticulo>? ClientesQueLoCompraron { get; set; }
    }
}
