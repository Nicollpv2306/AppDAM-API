using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerPedidos()
        {
            var lista = await Task.Run(() => new PedidoDAO().obtenerPedidos());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerPedido(int id)
        {
            var pedido = await Task.Run(() => new PedidoDAO().obtenerPedidoPorId(id));
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> registrarPedido(Pedido reg)
        {
            var mensaje = await Task.Run(() => new PedidoDAO().registrarPedido(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarPedido(Pedido reg)
        {
            var mensaje = await Task.Run(() => new PedidoDAO().actualizarPedido(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarPedido(int id)
        {
            var mensaje = await Task.Run(() => new PedidoDAO().eliminarPedido(id));
            return Ok(mensaje);
        }
    }
}
