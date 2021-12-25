using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double SpecialPrice { get; set; }
        public double PublicPrice { get; set; }
        public int Stock { get; set; }

        public Product(string productName, double specialPrice, double publicPrice, int stock)
        {
            this.ProductName = productName;
            this.SpecialPrice = specialPrice;
            this.PublicPrice = publicPrice;
            this.Stock = stock;
        }

        public Product(int productId, string productName, double specialPrice, double publicPrice, int stock)
        {
            this.ProductID = productId;
            this.ProductName = productName;
            this.SpecialPrice = specialPrice;
            this.PublicPrice = publicPrice;
            this.Stock = stock;
        }

        public override string ToString()
        {
            return $"Id: {this.ProductID} \nName: {this.ProductName} \nSpecial Price: {this.SpecialPrice} " +
                $"\nPublic Price: {this.PublicPrice} \nStock: {this.Stock}" + Environment.NewLine;
        }
    }
}
