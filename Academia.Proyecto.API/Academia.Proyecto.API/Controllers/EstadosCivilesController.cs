using Academia.Proyecto.API._Features.EstadosCiviles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosCivilesController : ControllerBase
    {
        private readonly EstadosCivilesService _estadosCivilesService;

        public EstadosCivilesController(EstadosCivilesService estadosCivilesService)
        {
            _estadosCivilesService = estadosCivilesService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _estadosCivilesService.ListarEstadosCiviles();
            return Ok(respuesta);
        }
    }
}
