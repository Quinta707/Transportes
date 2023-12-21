using Academia.Proyecto.API._Features.SucursalesXEmpleados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesXEmpleadosController : ControllerBase
    {
        private readonly SucursalesXEmpleadoService _sucursalesXEmpleadosService;

        public SucursalesXEmpleadosController(SucursalesXEmpleadoService sucursalesXEmpleadosService)
        {
            _sucursalesXEmpleadosService = sucursalesXEmpleadosService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalesXEmpleadosService.ListarSucursalXEmpleado();
            return Ok(respuesta);
        }
    }
}
