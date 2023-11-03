using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<RelacionArticuloTienda> RelacionesArticuloTienda { get; set; }
        public DbSet<RelacionClienteArticulo> RelacionesClienteArticulo { get; set; }
        public IEnumerable<object> RelacionArticuloCliente { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las relaciones, si es necesario
            modelBuilder.Entity<RelacionArticuloTienda>()
                .HasKey(rt => new { rt.ArticuloId, rt.TiendaId });

            modelBuilder.Entity<RelacionClienteArticulo>()
                .HasKey(ca => new { ca.ClienteId, ca.ArticuloId });
            modelBuilder.Entity<Articulo>()
        .Property(a => a.Precio)
        .HasColumnType("decimal(18, 2)");

            // Otras configuraciones de las entidades, si es necesario
        }
    }
}
