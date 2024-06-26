using AppDAM_API.Repositorio.DAO;
using AppDAM_API.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDAM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAppController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerLoginApps()
        {
            var lista = await Task.Run(() => new LoginAppDAO().obtenerLoginApps());
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerLoginApp(int id)
        {
            var login = await Task.Run(()=> new LoginAppDAO().obtenerLoginAppPorId(id));
            return Ok(login);
        }

        [HttpPost]
        public async Task<IActionResult> registrarLoginApp(LoginApp reg)
        {
            var mensaje = await Task.Run(() => new LoginAppDAO().registrarLoginApp(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarLoginApp(LoginApp reg)
        {
            var mensaje = await Task.Run(() => new LoginAppDAO().actualizarLoginApp(reg));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarLoginApp(int id)
        {
            var mensaje = await Task.Run(() => new LoginAppDAO().eliminarLoginApp(id));
            return Ok(mensaje);
        }
    }
}
