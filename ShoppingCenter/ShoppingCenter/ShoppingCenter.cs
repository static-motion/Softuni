using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class ShoppingCenter
    {
        private Dictionary<string, OrderedBag<Product>> byName;
        private Dictionary<string, OrderedBag<Product>> byProducer;
        private OrderedDictionary<double, OrderedBag<Product>> byPrice;
        private Dictionary<string, OrderedBag<Product>> byNameAndProducer;
        public ShoppingCenter()
        {
            this.byName = new Dictionary<string, OrderedBag<Product>>();
            this.byProducer = new Dictionary<string, OrderedBag<Product>>();
            this.byPrice = new OrderedDictionary<double, OrderedBag<Product>>();
            this.byNameAndProducer = new Dictionary<string, OrderedBag<Product>>();
        }
        public void AddProduct(string name, double price, string producer)
        {
            string nameAndProducer = GetKey(name, producer);
            if (!this.byName.ContainsKey(name))
            {
                this.byName.Add(name, new OrderedBag<Product>());
            }
            if (!this.byProducer.ContainsKey(producer))
            {
                this.byProducer.Add(producer, new OrderedBag<Product>());
            }
            if (!this.byPrice.ContainsKey(price))
            {
                this.byPrice.Add(price, new OrderedBag<Product>());
            }
            if (!this.byNameAndProducer.ContainsKey(nameAndProducer))
            {
                this.byNameAndProducer.Add(nameAndProducer, new OrderedBag<Product>());
            }
            Product product = new Product(name, price, producer);
            this.byName[name].Add(product);
            this.byProducer[producer].Add(product);
            this.byPrice[price].Add(product);
            this.byNameAndProducer[nameAndProducer].Add(product);
            Console.WriteLine("Product added");
        }

        private string GetKey(string name, string producer)
        {
            return name + producer;
        }

        public void DeleteProducts(string producer)
        {
            string key = "";
            int deleted = 0;
            if (this.byProducer.ContainsKey(producer))
            {
                deleted = this.byProducer[producer].Count;
                foreach (var product in this.byProducer[producer])
                {
                    key = GetKey(product.Name, product.Producer);
                    this.byName[product.Name].Remove(product);
                    this.byPrice[product.Price].Remove(product);
                    this.byNameAndProducer[key].Remove(product);
                }
                this.byProducer.Remove(producer);
            }
            if (deleted != 0)
            {
                Console.WriteLine($"{deleted} products deleted");
                return;
            }
            Console.WriteLine("No products found");
        }

        public void FindProductsByName(string name)
        {
            List<Product> products = new List<Product>();
            if (this.byName.ContainsKey(name))
            {
                products = byName[name].ToList();
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }
            Print(products);
        }

        public void FindProductsByProducer(string producer)
        {
            List<Product> products = new List<Product>();
            if (this.byProducer.ContainsKey(producer))
            {
                products = this.byProducer[producer].ToList();
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }
            Print(products);
        }

        public void FindProductsByPriceRange(double fromPrice, double toPrice)
        {
            OrderedBag<Product> products = new OrderedBag<Product>();
            foreach (var product in this.byPrice)
            {
                if (product.Key >= fromPrice && product.Key <= toPrice)
                {
                    products.AddMany(product.Value);
                }
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }
            Print(products);
        }

        private static void Print(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{{{product.Name};{product.Producer};{product.Price:F2}" + "}");
            }
        }

        public void DeleteProducts(string name, string producer)
        {
            var key = GetKey(name, producer);
            int deleted = 0;
            if (this.byNameAndProducer.ContainsKey(key))
            {
                deleted = this.byNameAndProducer[key].Count;
                foreach (var product in this.byNameAndProducer[key])
                {
                    this.byName[product.Name].Remove(product);
                    this.byProducer[product.Producer].Remove(product);
                    this.byPrice[product.Price].Remove(product);
                }
                this.byNameAndProducer.Remove(key);
            }
            if (deleted != 0)
            {
                Console.WriteLine($"{deleted} products deleted");
                return;
            }
            Console.WriteLine("No products found");
        }
    }
}
