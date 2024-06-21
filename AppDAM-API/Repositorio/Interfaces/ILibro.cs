using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface ILibro
    {
        IEnumerable<Libro> obtenerLibros();
        Libro obtenerLibroPorId(int id);
        string registrarLibro(Libro reg);
        string actualizarLibro(Libro reg);
        string eliminarLibro(int id);
    }
}
