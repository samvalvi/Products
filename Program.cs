using Products.dto;

namespace Products
{
    class TestDataBase
    {
        static void Main(string[] args)
        {
            ProductDTO product = new ProductDTO();
            var result = product.SearchById(2);
            Console.WriteLine(result);

            
        }
    }
}
