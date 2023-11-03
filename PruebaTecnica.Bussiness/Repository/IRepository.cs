using PruebaTecnica.Entities;
using PruebaTecnica.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Bussiness.Repository
{
    public interface IRepository
    {
        #region articulo
        Task<IEnumerable<Articulo>> GetAllArticulosAsync();
        Task<Articulo> GetArticuloByIdAsync(int id);
        Task AddArticuloAsync(Articulo articulo);
        Task UpdateArticuloAsync(Articulo articulo);
        Task DeleteArticuloAsync(int id);
        Task<List<Articulo>> getProductosCAsync(int id);
        Task AddCAAsync(RelacionClienteArticulo id);
        #endregion
        #region tienda
        Task<IEnumerable<Tienda>> GetAllTiendasAsync();
        Task<Tienda> GetTiendaByIdAsync(int id);
        Task AddTiendaAsync(Tienda tienda);
        Task UpdateTiendaAsync(Tienda tienda);
        Task DeleteTiendaAsync(int id);
        #endregion
        #region cliente
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
        Task<string> login(LoginModel model);
        #endregion
    }
}
