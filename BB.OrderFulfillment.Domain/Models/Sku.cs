using System;

namespace BB.OrderFulfillment.Domain.Models
{
    public class Sku
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Sku() { }

        public Sku(string name, decimal price, int quantity)
        {
            if(String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if(price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            if(quantity < 0) throw new ArgumentNullException(nameof(quantity));

            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return this.Price * this.Quantity;
        }
    }
}
