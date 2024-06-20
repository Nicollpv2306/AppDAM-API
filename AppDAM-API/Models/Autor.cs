namespace AppDAM_API.Models
{
    public class Autor
    {
        private int id_autor;
        private string nombre;
        private string apellido;

        public Autor()
        {
            id_autor = 0;
            nombre = "";
            apellido = "";
        }

        public Autor(int id_autor, string nombre, string apellido)
        {
            this.id_autor = id_autor;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public int Id_autor { get => id_autor; set => id_autor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}
