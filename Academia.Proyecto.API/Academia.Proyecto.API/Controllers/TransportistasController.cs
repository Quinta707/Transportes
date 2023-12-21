using Academia.Proyecto.API._Features.Transportistas;
using Academia.Proyecto.API._Features.Transportistas.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Proyecto.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistasController : ControllerBase
    {
        private readonly TransportistasService _transportistasService;

        public TransportistasController(TransportistasService transportistasService)
        {
            _transportistasService = transportistasService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _transportistasService.ListarTransportista();
            return Ok(respuesta);
        }

        //[HttpPost("Insertar")]
        //public IActionResult Insertar(TransportistasDto transportista)
        //{
        //    var respuesta = _transportistasService.InsertarTransportista(transportista);

        //    return Ok(respuesta);
        //}

        //[HttpPut("Editar")]
        //public IActionResult Editar(_TransportistasDto transportista)
        //{
        //    var respuesta = _transportistasService.EditarTransportistas(transportista);

        //    return Ok(respuesta);
        //}

        //[HttpPut("Eliminar")]
        //public IActionResult Eliminar(int Id)
        //{
        //    var respuesta = _transportistasService.EliminarTransportistas(Id);

        //    return Ok(respuesta);
        //}
    }
}
