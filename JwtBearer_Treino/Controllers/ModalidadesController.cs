using JwtBearer_Treino.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearer_Treino.Controllers
{
    [Route("api/modalidades")]
    [ApiController]
    public class ModalidadesController : ControllerBase
    {
        private readonly MainContext _ctx;

        public ModalidadesController(MainContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Unauthorized();
        }
    }
}