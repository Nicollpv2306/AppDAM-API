using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IAutor
    {
        IEnumerable<Autor> obtenerAutores();
        Autor obtenerAutorPorId(int id);
        int registrarAutor(Autor reg);
        int actualizarAutor(Autor reg);
        int eliminarAutor(int id);
    }
}
