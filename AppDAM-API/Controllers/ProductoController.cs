using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerProductos()
        {
            var lista = await Task.Run(() => new ProductoDAO().obtenerProductos());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerProducto(int id)
        {
            var producto = await Task.Run(() => new ProductoDAO().obtenerProductoPorId(id));
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> registrarProducto(Producto reg)
        {
            var mensaje = await Task.Run(() => new ProductoDAO().registrarProducto(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarProducto(Producto reg)
        {
            var mensaje = await Task.Run(() => new ProductoDAO().actualizarProducto(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarProducto(int id)
        {
            var mensaje = await Task.Run(() => new ProductoDAO().eliminarProducto(id));
            return Ok(mensaje);
        }
    }
}
