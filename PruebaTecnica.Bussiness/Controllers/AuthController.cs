using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Bussiness.Repository;
using PruebaTecnica.Entities;
using PruebaTecnica.Entitys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Pages
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IRepository _repository;

        public AuthController(IRepository Repository)
        {
            _repository = Repository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {

            string token = await _repository.login(model);
            if (token.IsNullOrEmpty())
            {
                return Unauthorized();
            }

           

            return Ok(new { Token = token });
        }      

    }
}
