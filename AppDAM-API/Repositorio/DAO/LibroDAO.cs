using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class LibroDAO : ILibro
    {
        private readonly string cadena;
        public LibroDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarLibro(Libro reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_libro", reg.Id_libro);
                cmd.Parameters.AddWithValue("@titulo", reg.Titulo);
                cmd.Parameters.AddWithValue("@id_autor", reg.Id_autor);
                cmd.Parameters.AddWithValue("@id_editorial", reg.Id_editorial);
                cmd.Parameters.AddWithValue("@descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@imagen", reg.Imagen);
                cmd.Parameters.AddWithValue("@id_categoria", reg.Id_categoria);
                cmd.Parameters.AddWithValue("@id_estado", reg.Id_estado);

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

        public string eliminarLibro(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_libro", id);

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

        public Libro obtenerLibroPorId(int id)
        {
            var libro = obtenerLibros().Where(c => c.Id_libro == id).FirstOrDefault();
            if (libro == null)
                return new Libro();
            else
                return libro;
        }

        public IEnumerable<Libro> obtenerLibros()
        {
            List<Libro> lstLibros = new List<Libro>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaLibros", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Libro reg = new Libro();

                reg.Id_libro = dr.GetInt32("id_libro");
                reg.Titulo = dr.GetString("titulo");
                reg.Id_autor = dr.GetInt32("id_autor");
                reg.Id_editorial = dr.GetInt32("id_editorial");
                reg.Descripcion = dr.GetString("descripcion");
                reg.Imagen = dr.GetString("imagen");
                reg.Id_categoria = dr.GetInt32("id_categoria");
                reg.Id_estado = dr.GetInt32("id_estado");

                lstLibros.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstLibros;
        }

        public string registrarLibro(Libro reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@titulo", reg.Titulo);
                cmd.Parameters.AddWithValue("@id_autor", reg.Id_autor);
                cmd.Parameters.AddWithValue("@id_editorial", reg.Id_editorial);
                cmd.Parameters.AddWithValue("@descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@imagen", reg.Imagen);
                cmd.Parameters.AddWithValue("@id_categoria", reg.Id_categoria);
                cmd.Parameters.AddWithValue("@id_estado", reg.Id_estado);

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
