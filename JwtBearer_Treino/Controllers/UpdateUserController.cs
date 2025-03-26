using System.Security.Claims;
using JwtBearer_Treino.Contexts;
using JwtBearer_Treino.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearer_Treino.Controllers
{
    [Route("api/usuarios/update/{id}")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class UpdateUserController : ControllerBase
    {
        private readonly MainContext _ctx;

        public UpdateUserController(MainContext ctx) { _ctx = ctx; }

        [HttpPut]
        public IActionResult UpdateUser(int Id, [FromBody] Usuario user)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null || userId != Id.ToString())
            {
                return Unauthorized("Você não tem permissão para alterar esse usuário.");
            }

            var usuarioValido = _ctx.Usuarios.FirstOrDefault(u => u.Id == Id);
            if (usuarioValido == null)
            {
                return NotFound("Usuário não encontrado");
            }

            usuarioValido.Nome = user.Nome;
            usuarioValido.Email = user.Email;
            usuarioValido.SenhaHash = user.SenhaHash;

            _ctx.SaveChanges();

            return Ok(usuarioValido);
        }
    }
}
