using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerCategorias()
        {
            var lista = await Task.Run(() => new CategoriaDAO().obtenerCategorias());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerCategoria(int id)
        {
            var categoria = await Task.Run(() => new CategoriaDAO().obtenerCategoriaPorId(id));
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> registrarCategoria(Categoria reg)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().registrarCategoria(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarCategoria(Categoria reg)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().actualizarCategoria(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarCategoria(int id)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().eliminarCategoria(id));
            return Ok(mensaje);
        }
    }
}
