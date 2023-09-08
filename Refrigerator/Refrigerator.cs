using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAthlock
{
    class Refrigerator
    {
        private readonly Dictionary<Product, int> products = new Dictionary<Product, int>();

        public void InsertProduct(string productName, int quantity, DateTime expiryDate)
        {
            var product = new Product { Name = productName, Quantity = quantity, ExpiryDate = expiryDate };
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
            }
            else
            {
                products.Add(product, quantity);
            }
        }

        public void ConsumeProduct(string productName, int quantity)
        {
            var product = products.Keys.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product != null && products[product] >= quantity)
            {
                products[product] -= quantity;
                if (products[product] == 0)
                {
                    products.Remove(product);
                }
            }
            else
            {
                Console.WriteLine($"Not enough {productName} in the refrigerator.");
            }
        }

        public Dictionary<Product, int> GetCurrentStatus()
        {
            return products;
        }

        public List<Product> CheckExpiry()
        {
            var currentDate = DateTime.Now;
            var expiredProducts = products.Keys.Where(p => p.ExpiryDate < currentDate).ToList();
            foreach (var product in expiredProducts)
            {
                products.Remove(product);
            }
            return expiredProducts;
        }
    }
}
