namespace AppDAM_API.Models
{
    public class LoginApp
    {
        private int id_login;
        private string usuario;
        private string contrasenia;

        public LoginApp()
        {
            id_login = 0;
            usuario = "";
            contrasenia = "";
        }

        public LoginApp(int id_login, string usuario, string contrasenia)
        {
            this.id_login = id_login;
            this.usuario = usuario;
            this.contrasenia = contrasenia;
        }

        public int Id_login { get => id_login; set => id_login = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
}
