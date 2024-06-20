namespace AppDAM_API.Models
{
    public class Usuario
    {
        private int id_usuario;
        private string nombre;
        private string apellido;
        private string correo;
        private string contrasenia;
        private string tipo_usuario;

        public Usuario()
        {
            id_usuario = 0;
            nombre = "";
            apellido = "";
            correo = "";
            contrasenia = "";
            tipo_usuario = "";
        }

        public Usuario(int id_usuario, string nombre, string apellido, string correo, string contrasenia, string tipo_usuario)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.tipo_usuario = tipo_usuario;
        }

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }
    }
}
