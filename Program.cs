using Products.dto;
using Products.model;

namespace Products
{
    class TestDataBase
    {
        static void Main(string[] args)
        {
            /*
                Product product = new Product("Ketchup", 1000, 1200, 12);
                ProductDTO dto = new ProductDTO();
                dto.InsertProduct(product);
            */

            /*
                ProductDTO dto = new ProductDTO();
                var result = dto.SearchById(3);
                Console.WriteLine(result);
            */

            /*
                Product product = new Product(11, "Queso", 1200, 1500, 13);
                ProductDTO productDTO = new ProductDTO();
                var result = productDTO.SearchById(11);
                if (result != null)
                {

                    productDTO.UpdateProduct(product);
                }
                else
                {
                    Console.WriteLine("Product doesn't exist.");
                }
            */

            ProductDTO dto = new ProductDTO();
            int id = 8;
            
            dto.DeleteProduct(id);
            

            
        }
    }
}
