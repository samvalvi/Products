using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.iproduct;
using Products.model;
using System.Data.SqlClient;
using Products.connection;

namespace Products.dto
{
    public class ProductDTO : IProduct
    {
        private readonly Connection connection;

        public ProductDTO()
        {
            connection = new Connection();
        }

        public List<Product> GetProducts()
        {
            string sql_query = "SELECT ProductoID, Nombre, PrecioEspecial, PrecioPublico, Stock FROM Producto";
            List<Product> products = new List<Product>();
            SqlConnection conn = connection.GetConnection();
                
            SqlCommand cmd = new SqlCommand(sql_query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal specialPrice = reader.GetDecimal(2);
                decimal publicPrice = reader.GetDecimal(3);
                int stock = reader.GetInt32(4);
                products.Add(new Product(id, name, (double)specialPrice, (double)publicPrice, stock));
            }
               

            connection.CloseConnection();
            return products;
        }

        public Product SearchById(int productId)
        {
            string sql_query = "SELECT ProductoID, Nombre, PrecioEspecial, PrecioPublico, Stock FROM Producto WHERE ProductoID = @productId";
            Product? product = null;

            SqlConnection conn = connection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql_query, conn);
            cmd.Parameters.AddWithValue("@productId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal specialPrice = reader.GetDecimal(2);
                decimal publicPrice = reader.GetDecimal(3);
                int stock = reader.GetInt32(4);

                product = new Product(id, name, (double)specialPrice, (double)publicPrice, stock);

            }
            connection.CloseConnection();
            #pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return product;
        }

        public void InsertProduct(Product product)
        {
            try
            {
                string sql_query = "INSERT INTO Producto(Nombre, PrecioEspecial, PrecioPublico, Stock) " +
                    "VALUES(@productName, @specialPrice, @publicPrice, @stock)";

                SqlConnection conn = connection.GetConnection();
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                cmd.Parameters.AddWithValue("@specialPrice", product.SpecialPrice);
                cmd.Parameters.AddWithValue("@publicPrice", product.PublicPrice);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Product added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                string sql_query = "UPDATE Producto SET Nombre = @productName, PrecioEspecial = @specialPrice, " +
                    "PrecioPublico = @publicPrice, Stock = @stock WHERE ProductoID = @productId";
                SqlConnection conn = connection.GetConnection();
                SqlCommand cmd = new SqlCommand(sql_query, conn);

                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                cmd.Parameters.AddWithValue("@specialPrice", product.SpecialPrice);
                cmd.Parameters.AddWithValue("@publicPrice", product.PublicPrice);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@productId", product.ProductID);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Product updated.");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                string slq_query = "DELETE FROM Producto WHERE ProductoID = @productId";
                SqlConnection conn = connection.GetConnection();
                SqlCommand cmd = new SqlCommand(slq_query, conn);

                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery ();

                Console.WriteLine("Product deleted.");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Product doesn't exist");
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}
