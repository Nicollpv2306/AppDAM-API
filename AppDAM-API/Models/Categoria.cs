namespace AppDAM_API.Models
{
    public class Categoria
    {
        private int id_categoria;
        private string nombre;

        public Categoria()
        {
            id_categoria = 0;
            nombre = "";
        }

        public Categoria(int id_categoria, string nombre)
        {
            this.id_categoria = id_categoria;
            this.nombre = nombre;
        }

        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
