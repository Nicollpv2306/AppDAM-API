using System.Data;
using AppDAM_API.Models;
using AppDAM_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace AppDAM_API.Repositorio.DAO
{
    public class PedidoDAO : IPedido
    {
        private readonly string cadena;
        public PedidoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }
        public string actualizarPedido(Pedido reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_updatePedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pedido", reg. Id_pedido);
                cmd.Parameters.AddWithValue("@nom_cli", reg.Nom_cli);
                cmd.Parameters.AddWithValue("@num_mesa", reg.Num_mesa);
                cmd.Parameters.AddWithValue("@detalle", reg.Detalle);
                cmd.Parameters.AddWithValue("@precio", reg.Precio);
                cmd.Parameters.AddWithValue("@id_producto", reg.Id_producto);

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

        public string eliminarPedido(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_deletePedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pedido", id);

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

        public Pedido obtenerPedidoPorId(int id)
        {
            var pedido = obtenerPedidos().Where(c => c.Id_pedido == id).FirstOrDefault();
            if (pedido == null)
                return new Pedido();
            else
                return pedido;
        }

        public IEnumerable<Pedido> obtenerPedidos()
        {
            List<Pedido> lstPedidos = new List<Pedido>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Pedido reg = new Pedido();

                reg.Id_pedido = dr.GetInt32("id_pedido");
                reg.Nom_cli = dr.GetString("nom_cli");
                reg.Num_mesa = dr.GetInt32("num_mesa");
                reg.Detalle = dr.GetString("detalle");
                reg.Precio = dr.GetDecimal("precio");
                reg.Id_producto = dr.GetInt32("id_producto");

                lstPedidos.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lstPedidos;
        }

        public string registrarPedido(Pedido reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("usp_addPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pedido", reg.Id_pedido);
                cmd.Parameters.AddWithValue("@nom_cli", reg.Nom_cli);
                cmd.Parameters.AddWithValue("@num_mesa", reg.Num_mesa);
                cmd.Parameters.AddWithValue("@detalle", reg.Detalle);
                cmd.Parameters.AddWithValue("@precio", reg.Precio);
                cmd.Parameters.AddWithValue("@id_producto", reg.Id_producto);

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
