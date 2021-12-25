using Products.dto;
using Products.model;

namespace Products
{
    class TestDataBase
    {
        static void Main(string[] args)
        {
            Product product = new Product("Ketchup", 1000, 1200, 12);
            ProductDTO dto = new ProductDTO();
            dto.InsertProduct(product);

            
        }
    }
}
