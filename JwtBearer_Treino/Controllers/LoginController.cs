using JwtBearer_Treino.Contexts;
using JwtBearer_Treino.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JwtBearer_Treino.Controllers
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo email não é email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha {  get; set; }

        public LoginModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }

    [Route("api/login")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MainContext _ctx;
        private readonly TokenService _tokenService;

        public LoginController(MainContext mainContext, TokenService tokenService)
        {
            _ctx = mainContext;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            try
            {
                var user = _ctx.Usuarios.FirstOrDefault(u => u.Email == login.Email);

                if (user == null)
                {
                    return Unauthorized("Email ou senha inválidos");
                }

                bool senhaValida = user.Senha == login.Senha;

                if (!senhaValida)
                {
                    return Unauthorized("Email ou senha inválidos");
                }

                string token = _tokenService.TokenGenerate(user);

                return Ok(new
                {
                    Token = token,
                    usuario = new
                    {
                        user.Id,
                        user.Nome,
                        user.Email,
                    },
                    horarioAcesso = DateTime.UtcNow.ToString("dd/MM/yyyy - HH:mm")
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao fazer login: " + ex.Message);
            }
            
        }
    }
}
