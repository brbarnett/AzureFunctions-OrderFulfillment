#r "../bin/BB.OrderFulfillment.Domain.dll"
#r "../bin/BB.OrderFulfillment.Orders.dll"

using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders;

public static async Task Run(
    HttpRequestMessage req,
    string ordersQueueItem,
    IAsyncCollector<StorageModels.OrderEntity> ordersTable,
    TraceWriter log)
{
    try
    {
        ExternalModels.ECommerceOrder rawOrder = JsonConvert.DeserializeObject<ExternalModels.ECommerceOrder>(ordersQueueItem);

        Services.IOrderMapper orderMapper = new Services.OrderMapper();
        Order order = orderMapper.Map(rawOrder);

        await ordersTable.AddAsync(new StorageModels.OrderEntity
        {
            PartitionKey = "Orders",
            RowKey = order.Id,
            Order = order,
            ExternalOrder = rawOrder
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