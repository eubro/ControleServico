using Microsoft.AspNetCore.Mvc;

namespace ControleServicoAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CadServicoController : Controller
    {
        [HttpGet]
        public IActionResult get()
        {
            return Ok("Serviços");
        }

        [HttpPost]
        public IActionResult post()
        {

        }
    }
}
