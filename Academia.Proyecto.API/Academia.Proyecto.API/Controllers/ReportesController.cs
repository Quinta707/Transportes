using Academia.Proyecto.API._Features.Reportes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        ReportesService _reportesService;

        public ReportesController(ReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpGet("ReporteEmpleados")]
        public IActionResult ReporteEmpleados()
        {
            var respuesta = _reportesService.ReporteViajesEmpleados();
            return Ok(respuesta);
        }
    }
}
