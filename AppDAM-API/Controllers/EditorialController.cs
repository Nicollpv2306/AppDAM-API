using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerEditoriales()
        {
            var lista = await Task.Run(() => new EditorialDAO().obtenerEditoriales());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerEditorial(int id)
        {
            var editorial = await Task.Run(() => new EditorialDAO().obtenerEditorialPorId(id));
            return Ok(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> registrarEditorial(Editorial reg)
        {
            var mensaje = await Task.Run(() => new EditorialDAO().registrarEditorial(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarEditorial(Editorial reg)
        {
            var mensaje = await Task.Run(() => new EditorialDAO().actualizarEditorial(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarEditorial(int id)
        {
            var mensaje = await Task.Run(() => new EditorialDAO().eliminarEditorial(id));
            return Ok(mensaje);
        }
    }
}
