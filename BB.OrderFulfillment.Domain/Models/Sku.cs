using System;

namespace BB.OrderFulfillment.Domain.Models
{
    public class Sku
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Sku() { }

        public Sku(string id, decimal price, int quantity)
        {
            if(String.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if(price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            if(quantity < 0) throw new ArgumentNullException(nameof(quantity));

            this.Id = id;
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return this.Price * this.Quantity;
        }
    }
}
