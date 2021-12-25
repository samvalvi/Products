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
            string sql_query = $"SELECT ProductoID, Nombre, PrecioEspecial, PrecioPublico, Stock FROM Producto WHERE ProductoID = {productId}";
            Product product;

            SqlConnection conn = connection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql_query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            decimal specialPrice = reader.GetDecimal(2);
            decimal publicPrice = reader.GetDecimal(3);
            int stock = reader.GetInt32(4);

            product = new Product(id, name, (double)specialPrice, (double)publicPrice, stock);

            return product;
        }

        public void UpdateProduct(int productId)
        {
        }

        public void DeleteProduct(int productId)
        {
        }
    }
}
