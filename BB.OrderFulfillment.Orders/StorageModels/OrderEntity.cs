using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.ExternalModels;
using Microsoft.WindowsAzure.Storage.Table;

namespace BB.OrderFulfillment.Orders.StorageModels
{
    public class OrderEntity : TableEntity
    {
        public ECommerceOrder ExternalOrder { get; set; }

        public Order Order { get; set; }
    }
}
