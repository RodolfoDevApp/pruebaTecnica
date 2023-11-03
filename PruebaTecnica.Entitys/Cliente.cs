using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string password { get; set; }

        // Relación con los Artículos comprados por el Cliente
        public ICollection<RelacionClienteArticulo>? ArticulosComprados { get; set; }
    }
}
