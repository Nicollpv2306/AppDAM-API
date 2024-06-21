using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class AutorDAO : IAutor
    {
        private readonly string cadena;
        public AutorDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarAutor(Autor reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateAutor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_autor", reg.Id_autor);
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@apellido", reg.Apellido);

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

        public string eliminarAutor(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteAutor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_autor", id);

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

        public IEnumerable<Autor> obtenerAutores()
        {
            List<Autor> lstAutores = new List<Autor>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaAutores", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Autor reg = new Autor();

                reg.Id_autor = dr.GetInt32("id_autor");
                reg.Nombre = dr.GetString("nombre");
                reg.Apellido = dr.GetString("apellido");

                lstAutores.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstAutores;
        }

        public Autor obtenerAutorPorId(int id)
        {
            var autor = obtenerAutores().Where(c => c.Id_autor == id).FirstOrDefault();
            if (autor == null)
                return new Autor();
            else
                return autor;
        }

        public string registrarAutor(Autor reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addAutor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@apellido", reg.Apellido);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Registro Exitoso - Cantidad de filas insertadas: " + resultado;
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
    }
}
