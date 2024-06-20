using System.Globalization;

namespace AppDAM_API.Models
{
    public class Libro
    {
        private int id_libro;
        private string titulo;
        private int id_autor;
        private int id_editorial;
        private string descripcion;
        private string imagen;
        private int id_categoria;
        private int id_estado;

        public Libro()
        {
            id_libro = 0;
            titulo = "";
            id_autor = 0;
            id_editorial = 0;
            descripcion = "";
            imagen = "";
            id_categoria = 0;
            id_estado = 0;
        }

        public Libro(int id_libro, string titulo, int id_autor, int id_editorial, string descripcion, string imagen,
            int id_categoria, int id_estado)
        {
            this.id_libro = id_libro;
            this.titulo = titulo;
            this.id_autor = id_autor;
            this.id_editorial = id_editorial;
            this.descripcion = descripcion;
            this.imagen = imagen;
            this.id_categoria = id_categoria;
            this.id_estado = id_estado;
        }

        public int Id_libro { get => id_libro; set => id_libro = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int Id_autor { get => id_autor; set => id_autor = value; }
        public int Id_editorial { get => id_editorial; set => id_editorial = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public int Id_estado { get => id_estado; set => id_estado = value; }
    }
}
