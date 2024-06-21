using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerLibros()
        {
            var lista = await Task.Run(() => new LibroDAO().obtenerLibros());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerLibro(int id)
        {
            var libro = await Task.Run(() => new LibroDAO().obtenerLibroPorId(id));
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> registrarLibro(Libro reg)
        {
            var mensaje = await Task.Run(() => new LibroDAO().registrarLibro(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarLibro(Libro reg)
        {
            var mensaje = await Task.Run(() => new LibroDAO().actualizarLibro(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarLibro(int id)
        {
            var mensaje = await Task.Run(() => new LibroDAO().eliminarLibro(id));
            return Ok(mensaje);
        }
    }
}
