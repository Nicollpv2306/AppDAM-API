using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class LoginAppDAO : ILoginApp
    {
        private readonly string cadena;
        public LoginAppDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public string actualizarLoginApp(LoginApp reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateLoginApp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_login", reg.Id_login);
                cmd.Parameters.AddWithValue("@usuario", reg.Usuario);
                cmd.Parameters.AddWithValue("@contrasenia", reg.Contrasenia);

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

        public string eliminarLoginApp(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteLoginApp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_login", id);

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

        public LoginApp obtenerLoginAppPorId(int id)
        {
            var login = obtenerLoginApps().Where(c => c.Id_login == id).FirstOrDefault();
            if(login == null)
                return new LoginApp();
            else
                return login;
        }

        public IEnumerable<LoginApp> obtenerLoginApps()
        {
            List<LoginApp> lstLoginApps = new List<LoginApp>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaLoginApp", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LoginApp reg = new LoginApp();

                reg.Id_login = dr.GetInt32("id_login");
                reg.Usuario = dr.GetString("usuario");
                reg.Contrasenia = dr.GetString("contrasenia");

                lstLoginApps.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstLoginApps;
        }

        public string registrarLoginApp(LoginApp reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addLoginApp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", reg.Usuario);
                cmd.Parameters.AddWithValue("@contrasenia", reg.Contrasenia);

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
