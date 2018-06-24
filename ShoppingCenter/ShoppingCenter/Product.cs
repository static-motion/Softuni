using System;

namespace ShoppingCenter
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public int CompareTo(Product other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Producer.CompareTo(other.Producer);
            }
            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
            }
            return result;
        }
    }
}