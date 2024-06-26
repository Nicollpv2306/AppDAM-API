using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface ILoginApp
    {
        IEnumerable<LoginApp> obtenerLoginApps();
        LoginApp obtenerLoginAppPorId(int id);
        string registrarLoginApp(LoginApp reg);
        string actualizarLoginApp(LoginApp reg);
        string eliminarLoginApp(int id);
    }
}
