using Microsoft.AspNetCore.Mvc;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("saludo")]
        public IActionResult GETSaludo()
        {
            return Ok(new
            {
                msg = "Hola"
            });
        }
    }
}
