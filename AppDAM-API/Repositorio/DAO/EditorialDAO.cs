using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class EditorialDAO : IEditorial
    {
        private readonly string cadena;
        public EditorialDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarEditorial(Editorial reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateEditorial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_editorial", reg.Id_editorial);
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@direccion", reg.Direccion);
                cmd.Parameters.AddWithValue("@correo", reg.Correo);

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

        public string eliminarEditorial(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteEditorial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_editorial", id);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Eliminacion Exitosa - Cantidad de filas eliminadas: " + resultado;
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

        public IEnumerable<Editorial> obtenerEditoriales()
        {
            List<Editorial> lstEditoriales = new List<Editorial>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaEditoriales", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Editorial reg = new Editorial();

                reg.Id_editorial = dr.GetInt32("id_editorial");
                reg.Nombre = dr.GetString("nombre");
                reg.Direccion = dr.GetString("direccion");
                reg.Correo = dr.GetString("correo");

                lstEditoriales.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstEditoriales;
        }

        public Editorial obtenerEditorialPorId(int id)
        {
            var editorial = obtenerEditoriales().Where(c => c.Id_editorial == id).FirstOrDefault();
            if (editorial == null)
                return new Editorial();
            else
                return editorial;
        }

        public string registrarEditorial(Editorial reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addEditorial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@direccion", reg.Direccion);
                cmd.Parameters.AddWithValue("@correo", reg.Correo);

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
