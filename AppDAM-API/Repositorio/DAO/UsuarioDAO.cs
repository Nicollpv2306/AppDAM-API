using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class UsuarioDAO : IUsuario
    {
        private readonly string cadena;
        public UsuarioDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public string actualizarUsuario(Usuario reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", reg.Id_usuario);
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@apellido", reg.Apellido);
                cmd.Parameters.AddWithValue("@correo", reg.Correo);
                cmd.Parameters.AddWithValue("@contrasenia", reg.Contrasenia);
                cmd.Parameters.AddWithValue("@tipo_usuario", reg.Tipo_usuario);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Actualizacion Exitosa - Cantidad de filas actualizadas: " + resultado;

            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

        public string eliminarUsuario(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", id);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Eliminacion exitosa - Cantidad de filas eliminadas: " + resultado;
            }
            catch(SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

        public Usuario obtenerUsuarioPorId(int id)
        {
            var usuario = obtenerUsuarios().Where(c => c.Id_usuario == id).FirstOrDefault();
            if(usuario == null)
                return new Usuario();
            else
                return usuario;
        }

        public IEnumerable<Usuario> obtenerUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Usuario reg = new Usuario();

                reg.Id_usuario = dr.GetInt32("id_usuario");
                reg.Nombre = dr.GetString("nombre");
                reg.Apellido = dr.GetString("apellido");
                reg.Correo = dr.GetString("correo");
                reg.Contrasenia = dr.GetString("contrasenia");
                reg.Tipo_usuario = dr.GetString("tipo_usuario");

                lstUsuarios.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstUsuarios;
        }

        public string registrarUsuario(Usuario reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@apellido", reg.Apellido);
                cmd.Parameters.AddWithValue("@correo", reg.Correo);
                cmd.Parameters.AddWithValue("@contrasenia", reg.Contrasenia);
                cmd.Parameters.AddWithValue("@tipo_usuario", reg.Tipo_usuario);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Registro Exitoso - Cantidad de filas insertadas: " + resultado;

            }
            catch(SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

    }
}
