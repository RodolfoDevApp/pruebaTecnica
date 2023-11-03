using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Data;
using PruebaTecnica.Entities;
using PruebaTecnica.Entitys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Bussiness.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _config;

        public Repository(ApplicationDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IEnumerable<Articulo>> GetAllArticulosAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo> GetArticuloByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }
        public async Task<List<Articulo>> getProductosCAsync(int clienteId)
        {
            return await _context.RelacionesClienteArticulo
                .Where(ra => ra.ClienteId == clienteId)
                .Join(
                    _context.Articulos,
                    ra => ra.ArticuloId,
                    articulo => articulo.ArticuloId,
                    (ra, articulo) => new Articulo
                    {
                        ArticuloId = articulo.ArticuloId,
                        Codigo = articulo.Codigo
                    }
                )
                .ToListAsync();
        }


        public async Task AddArticuloAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }
        public async Task AddCAAsync(RelacionClienteArticulo articulo)
        {
            _context.RelacionesClienteArticulo.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticuloAsync(Articulo articulo)
        {
            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticuloAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Tienda>> GetAllTiendasAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        public async Task AddTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiendaAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            // Encripta la contraseña antes de almacenarla
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(cliente.password);

            // Asigna la contraseña encriptada al cliente
            cliente.password = hashedPassword;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> login(LoginModel model)

        {
            var user = _context.Clientes.SingleOrDefault(u => u.Nombre == model.Nombre);

            if (user == null || !VerifyPassword(user.password, model.password))
            {
                return "";
            }

            var token = GenerateJwtToken(user.Nombre,user.ClienteId);

            return token;
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword); ;
        }

        private string GenerateJwtToken(string userName,int userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                new[]
                {
                
                new Claim(JwtRegisteredClaimNames.UniqueName, userName), // Agrega el nombre de usuario como reclamación
                new Claim(ClaimTypes.Dns, userId.ToString())
                },
                expires: DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:ExpirationHours"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
