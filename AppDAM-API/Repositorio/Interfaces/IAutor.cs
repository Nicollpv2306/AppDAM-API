using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IAutor
    {
        IEnumerable<Autor> obtenerAutores();
        Autor obtenerAutorPorId(int id);
        string registrarAutor(Autor reg);
        string actualizarAutor(Autor reg);
        string eliminarAutor(int id);
    }
}
