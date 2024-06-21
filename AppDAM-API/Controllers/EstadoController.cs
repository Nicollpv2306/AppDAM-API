using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerEstados()
        {
            var lista = await Task.Run(() => new EstadoDAO().obtenerEstados());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerEstado(int id)
        {
            var estado = await Task.Run(() => new EstadoDAO().obtenerEstadoPorId(id));
            return Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> registrarEstado(Estado reg)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().registrarEstado(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarEstado(Estado reg)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().actualizarEstado(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarEstado(int id)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().eliminarEstado(id));
            return Ok(mensaje);
        }
    }
}
