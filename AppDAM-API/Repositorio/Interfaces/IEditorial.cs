using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IEditorial
    {
        IEnumerable<Editorial> obtenerEditoriales();
        Editorial obtenerEditorialPorId(int id);
        string registrarEditorial(Editorial reg);
        string actualizarEditorial(Editorial reg);
        string eliminarEditorial(int id);
    }
}
