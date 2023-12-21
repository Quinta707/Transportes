using Academia.Proyecto.API._Features.Sucursales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly SucursalesService _sucursalesService;

        public SucursalesController(SucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalesService.ListarSucursales();
            return Ok(respuesta);
        }
    }
}
