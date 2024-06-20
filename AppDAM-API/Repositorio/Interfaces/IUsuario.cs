using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> obtenerUsuarios();
        Usuario obtenerUsuarioPorId(int id);
        int registrarUsuario(Usuario reg);
        int actualizarUsuario(Usuario reg);
        int eliminarUsuario(int id);
    }
}
