using System;
using System.Collections.Generic;
using System.Linq;

namespace BB.OrderFulfillment.Domain.Models
{
    public class Order
    {
        public string Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public IEnumerable<Sku> Skus { get; set; }

        public Order() { }

        public Order(string id, string customerName, string customerAddress, ICollection<Sku> skus)
        {
            if(String.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if(String.IsNullOrEmpty(customerName)) throw new ArgumentNullException(nameof(customerName));
            if(String.IsNullOrEmpty(customerAddress)) throw new ArgumentNullException(nameof(customerAddress));
            if(!skus.Any()) throw new ArgumentException("Order must contain sold SKUs", nameof(skus));

            this.Id = id;
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.Skus = skus;
        }

        public decimal GetOrderTotal()
        {
            return this.Skus.Sum(_ => _.GetTotalCost());
        }
    }
}
