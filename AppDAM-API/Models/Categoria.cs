namespace AppDAM_API.Models
{
    public class Categoria
    {
        private int id_categoria;
        private string nombre;
        private string descripcion;

        public Categoria()
        {
            id_categoria = 0;
            nombre = "";
            descripcion = "";
        }

        public Categoria(int id_categoria, string nombre, string descripcion)
        {
            this.id_categoria = id_categoria;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
