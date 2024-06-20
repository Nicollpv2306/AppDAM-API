using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IEstado
    {
        IEnumerable<Estado> obtenerEstados();
        Estado obtenerEstadoPorId(int id);
        int registrarEstado(Estado reg);
        int actualizarEstado(Estado reg);
        int eliminarEstado(int id);
    }
}
