using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entities
{
    public class Tienda
    {
        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        // Relación con los Artículos disponibles en la Tienda
        public ICollection<RelacionArticuloTienda>? ArticulosDisponibles { get; set; }
    }
}
