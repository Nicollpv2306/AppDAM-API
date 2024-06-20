using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IEditorial
    {
        IEnumerable<Editorial> obtenerEditoriales();
        Editorial obtenerEditorialPorId(int id);
        int registrarEditorial(Editorial reg);
        int actualizarEditorial(Editorial reg);
        int eliminarEditorial(int id);
    }
}
