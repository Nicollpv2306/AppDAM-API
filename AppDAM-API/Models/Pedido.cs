using System.Globalization;

namespace AppDAM_API.Models
{
    public class Pedido
    {
        private int id_pedido;
        private string nom_cli;
        private int num_mesa;
        private string detalle;
        private decimal precio;
        private int id_producto;

        public Pedido()
        {
            id_pedido = 0;
            nom_cli = "";
            num_mesa = 0;
            detalle = "";
            precio = 0;
            id_producto = 0;
        }

        public Pedido(int id_pedido, string nom_cli, int num_mesa, string detalle, decimal precio, int id_producto)
        {
            this.id_pedido = id_pedido;
            this.nom_cli = nom_cli;
            this.num_mesa = num_mesa;
            this.detalle = detalle;
            this.precio = precio;
            this.id_producto = id_producto;
        }

        public int Id_pedido { get => id_pedido; set => id_pedido = value; }
        public string Nom_cli { get => nom_cli; set => nom_cli = value; }
        public int Num_mesa { get => num_mesa; set => num_mesa = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
    }
}
