using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaDarwinRugama.Models;
using PruebaDarwinRugama.Utility;
using System.Data;

namespace PruebaDarwinRugama.Controllers
{
    public class ProductoController : Controller
    {
        string connectionString = Utility.ConectionString.CName;
        public IActionResult Index()
        {
            return View();
        }

       
        public ActionResult CreateProducto()
        {
            return View();
        }

        // GET: Producto/AddProducto  
        public ActionResult AddProducto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducto(Productos productos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PACrearProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@CodigoProducto", productos.codigoProducto);
                cmd.Parameters.AddWithValue("@Precio", productos.precioProducto);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }

        public void Actualizar(Productos productos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PAActualizarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idproducto", productos.Id);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@CodigoProducto", productos.codigoProducto);
                cmd.Parameters.AddWithValue("@Precio", productos.precioProducto);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Eliminar(Productos productos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PAEliminarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idproducto", productos.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
