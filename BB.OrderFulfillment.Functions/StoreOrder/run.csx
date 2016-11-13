#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"
#r "../bin/BB.OrderFulfillment.Domain.dll"
#r "../bin/BB.OrderFulfillment.Orders.dll"

using Newtonsoft.Json;

using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.ExternalModels;
using BB.OrderFulfillment.Orders.Services;
using BB.OrderFulfillment.Orders.StorageModels;

public static async Task Run(
    string ordersQueueItem,
    IQueryable<OrderEntity> queryableOrdersTable,
    IAsyncCollector<OrderEntity> ordersTable,
    TraceWriter log)
{
    try
    {
        ECommerceOrder rawOrder = JsonConvert.DeserializeObject<ECommerceOrder>(ordersQueueItem);

        IOrderMapper orderMapper = new OrderMapper();
        Order order = orderMapper.Map(rawOrder);

        OrderEntity existingOrder = queryableOrdersTable.Where(p => p.RowKey == order.Id).SingleOrDefault();
        if (existingOrder != null) return;

        await ordersTable.AddAsync(new OrderEntity
        {
            PartitionKey = "Orders",
            RowKey = order.Id,
            SerializedOrder = JsonConvert.SerializeObject(order),
            SerializedExternalOrder = ordersQueueItem
        });
    }
    catch (Exception ex)
    {
        log.Info($"Error receiving data: {ex}");

        // handle exception for further processing. consider handling different exceptions separately,
        // where some might cause retries (as thrown exceptions, which will cause a requeue) and others 
        // might store poisonous messages to a new {queueName}-error queue
    }
}