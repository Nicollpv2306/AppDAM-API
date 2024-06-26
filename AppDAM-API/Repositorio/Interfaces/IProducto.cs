using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IProducto
    {
        IEnumerable<Producto> obtenerProductos();
        Producto obtenerProductoPorId(int id);
        string registrarProducto(Producto reg);
        string actualizarProducto(Producto reg);
        string eliminarProducto(int id);
    }
}
