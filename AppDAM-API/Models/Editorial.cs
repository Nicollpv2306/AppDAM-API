namespace AppDAM_API.Models
{
    public class Editorial
    {
        private int id_editorial;
        private string nombre;
        private string direccion;
        private string correo;

        public Editorial()
        {
            id_editorial = 0;
            nombre = "";
            direccion = "";
            correo = "";
        }

        public Editorial(int id_editorial, string nombre, string direccion, string correo)
        {
            this.id_editorial = id_editorial;
            this.nombre = nombre;
            this.direccion = direccion;
            this.correo = correo;
        }

        public int Id_editorial { get => id_editorial; set => id_editorial = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
