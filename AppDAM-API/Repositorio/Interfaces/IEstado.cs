using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IEstado
    {
        IEnumerable<Estado> obtenerEstados();
        Estado obtenerEstadoPorId(int id);
        string registrarEstado(Estado reg);
        string actualizarEstado(Estado reg);
        string eliminarEstado(int id);
    }
}
