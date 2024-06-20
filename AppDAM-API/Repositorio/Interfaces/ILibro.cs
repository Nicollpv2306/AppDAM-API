using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface ILibro
    {
        IEnumerable<Libro> obtenerLibros();
        Libro obtenerLibroPorId(int id);
        int registrarLibro(Libro reg);
        int actualizarLibro(Libro reg);
        int eliminarLibro(int id);
    }
}
