using Products.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.iproduct
{
    public interface IProduct
    {
        public List<Product> GetProducts();
        public Product SearchById(int productId);
        public void InsertProduct(Product product);
        public void UpdateProduct(int productId);
        public void DeleteProduct(int productId);
    }
}
