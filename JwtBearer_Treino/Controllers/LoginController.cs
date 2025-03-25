using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearer_Treino.Controllers
{
    [Route("api/v1/login")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get()
        {
            return null;
        }
    }
}
