using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> obtenerUsuarios();
        Usuario obtenerUsuarioPorId(int id);
        string registrarUsuario(Usuario reg);
        string actualizarUsuario(Usuario reg);
        string eliminarUsuario(int id);
    }
}
