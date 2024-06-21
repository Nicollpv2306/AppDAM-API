using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface ICategoria
    {
        IEnumerable<Categoria> obtenerCategorias();
        Categoria obtenerCategoriaPorId(int id);
        string registrarCategoria(Categoria reg);
        string actualizarCategoria(Categoria reg);
        string eliminarCategoria(int id);
    }
}
