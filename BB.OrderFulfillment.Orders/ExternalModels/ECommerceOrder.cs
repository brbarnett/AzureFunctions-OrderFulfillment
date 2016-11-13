using System.Collections.Generic;

namespace BB.OrderFulfillment.Orders.ExternalModels
{
    public class ECommerceOrder
    {
        public int OrderNumber { get; set; }

        public string Customer { get; set; }

        public string ShipToAddress { get; set; }

        public IEnumerable<ECommerceSku> SoldItems { get; set; }
    }
}
