using JwtBearer_Treino.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearer_Treino.Controllers
{
    public class UsuarioModel()
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    [Route("api/usuarios")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly MainContext _ctx;

        public UsuariosController(MainContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userList = _ctx.Usuarios.ToList();

            var usuariosModel = userList.Select(u => new UsuarioModel
            {
                Id = u.Id.ToString(),
                Nome = u.Nome,
                Email = u.Email
            }).ToList();

            return Ok(usuariosModel);
        }
    }
}
