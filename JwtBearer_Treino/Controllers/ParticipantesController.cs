using JwtBearer_Treino.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearer_Treino.Controllers
{
    [Route("api/participantes")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ParticipantesController : ControllerBase
    {
        private readonly MainContext _ctx;

        public ParticipantesController(MainContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ctx.Participantes.ToList());
        }

        [HttpPost("{nome}")]
        public IActionResult Post(string nome)
        {
            var participantesBuscados = _ctx.Participantes.Where(m => m.Nome.ToLower().StartsWith(nome.ToLower())).ToList();

            if (participantesBuscados == null)
            {
                return BadRequest("Modalidade não encontrada");
            }

            return Ok(participantesBuscados);
        }
    }
}
