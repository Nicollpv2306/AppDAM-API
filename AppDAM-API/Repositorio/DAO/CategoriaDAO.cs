using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class CategoriaDAO : ICategoria
    {
        private readonly string cadena;
        public CategoriaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarCategoria(Categoria reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_categoria", reg.Id_categoria);
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);

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

        public string eliminarCategoria(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_categoria", id);

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

        public Categoria obtenerCategoriaPorId(int id)
        {
            var categoria = obtenerCategorias().Where(c => c.Id_categoria == id).FirstOrDefault();
            if (categoria == null)
                return new Categoria();
            else
                return categoria;
        }

        public IEnumerable<Categoria> obtenerCategorias()
        {
            List<Categoria> lstCategorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaCategorias", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Categoria reg = new Categoria();

                reg.Id_categoria = dr.GetInt32("id_categoria");
                reg.Nombre = dr.GetString("nombre");

                lstCategorias.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstCategorias;
        }

        public string registrarCategoria(Categoria reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);

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
