namespace AppDAM_API.Models
{
    public class Estado
    {
        private int id_estado;
        private string tipo_estado;

        public Estado()
        {
            id_estado = 0;
            tipo_estado = "";
        }

        public Estado(int id_estado, string tipo_estado)
        {
            this.id_estado = id_estado;
            this.tipo_estado = tipo_estado;
        }

        public int Id_estado { get => id_estado; set => id_estado = value; }
        public string Tipo_estado { get => tipo_estado; set => tipo_estado = value; }
    }
}
