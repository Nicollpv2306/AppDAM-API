using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface ICategoria
    {
        IEnumerable<Categoria> obtenerCategorias();
        Categoria obtenerCategoriaPorId(int id);
        int registrarCategoria(Categoria reg);
        int actualizarCategoria(Categoria reg);
        int eliminarCategoria(int id);
    }
}
