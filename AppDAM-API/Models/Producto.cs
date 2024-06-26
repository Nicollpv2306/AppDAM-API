namespace AppDAM_API.Models
{
    public class Producto
    {
        private int id_producto;
        private string nombre;
        private decimal precio;
        private string descripcion;
        private string foto;
        private int id_categoria;

        public Producto()
        {
            id_producto = 0;
            nombre = "";
            precio = 0;
            descripcion = "";
            foto = "";
            id_categoria = 0;
        }

        public Producto(int id_producto, string nombre, decimal precio, string descripcion, string foto, int id_categoria)
        {
            this.id_producto = id_producto;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.foto = foto;
            this.id_categoria = id_categoria;
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Foto { get => foto; set => foto = value; }
        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
    }
}
