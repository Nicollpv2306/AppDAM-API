using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class ProductoDAO : IProducto
    {
        private readonly string cadena;
        public ProductoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarProducto(Producto reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_producto", reg.Id_producto);
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@precio", reg.Precio);
                cmd.Parameters.AddWithValue("@descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@foto", reg.Foto);
                cmd.Parameters.AddWithValue("@id_categoria", reg.Id_categoria);

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

        public string eliminarProducto(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_producto", id);

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

        public IEnumerable<Producto> obtenerProductos()
        {
            List<Producto> lstProductos = new List<Producto>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Producto reg = new Producto();

                reg.Id_producto = dr.GetInt32("id_producto");
                reg.Nombre = dr.GetString("nombre");
                reg.Precio = dr.GetDecimal("precio");
                reg.Descripcion = dr.GetString("descripcion");
                reg.Foto = dr.GetString("foto");
                reg.Id_categoria = dr.GetInt32("id_categoria");

                lstProductos.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstProductos;
        }

        public Producto obtenerProductoPorId(int id)
        {
            var producto = obtenerProductos().Where(c => c.Id_producto == id).FirstOrDefault();
            if (producto == null)
                return new Producto();
            else
                return producto;
        }

        public string registrarProducto(Producto reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@precio", reg.Precio);
                cmd.Parameters.AddWithValue("@descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@foto", reg.Foto);
                cmd.Parameters.AddWithValue("@id_categoria", reg.Id_categoria);

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
