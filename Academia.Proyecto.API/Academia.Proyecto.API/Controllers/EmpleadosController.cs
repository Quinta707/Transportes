using Academia.Proyecto.API._Features.Empleados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _empleadosService;

        public EmpleadosController(EmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _empleadosService.ListarEmpleados();
            return Ok(respuesta);
        }
    }
}
