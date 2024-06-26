using AppDAM_API.Models;

namespace AppDAM_API.Repositorio.Interfaces
{
    public interface IPedido
    {
        IEnumerable<Pedido> obtenerPedidos();
        Pedido obtenerPedidoPorId(int id);
        string registrarPedido(Pedido reg);
        string actualizarPedido(Pedido reg);
        string eliminarPedido(int id);
    }
}
