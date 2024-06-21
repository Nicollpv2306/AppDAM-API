using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerUsuarios()
        {
            var lista = await Task.Run(() => new UsuarioDAO().obtenerUsuarios());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerUsuario(int id)
        {
            var usuario = await Task.Run(()=> new UsuarioDAO().obtenerUsuarioPorId(id));
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> registrarUsuario(Usuario reg)
        {
            var mensaje = await Task.Run(() => new UsuarioDAO().registrarUsuario(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarUsuario(Usuario reg)
        {
            var mensaje = await Task.Run(() => new UsuarioDAO().actualizarUsuario(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarUsuario(int id)
        {
            var mensaje = await Task.Run(() => new UsuarioDAO().eliminarUsuario(id));
            return Ok(mensaje);
        }
    }
}
