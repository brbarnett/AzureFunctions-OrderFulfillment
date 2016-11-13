using Microsoft.WindowsAzure.Storage.Table;

namespace BB.OrderFulfillment.Orders.StorageModels
{
    public class OrderEntity : TableEntity
    {
        public string SerializedExternalOrder { get; set; }

        public string SerializedOrder { get; set; }
    }
}
