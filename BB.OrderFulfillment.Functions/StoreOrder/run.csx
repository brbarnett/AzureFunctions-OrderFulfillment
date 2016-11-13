#r "../bin/BB.OrderFulfillment.Domain.dll"
#r "../bin/BB.OrderFulfillment.Orders.dll"

using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders;

public static async Task Run(
    HttpRequestMessage req,
    IAsyncCollector<Order> ordersQueue,
    TraceWriter log)
{
    string rawOrder = await req.Content.ReadAsStringAsync();
    log.Info($"Received new order: {rawOrder}");

    try
    {
        ExternalModels.ECommerceOrder postedOrder = JsonConvert.DeserializeObject<ExternalModels.ECommerceOrder>(message);
        
        await ordersQueue.AddAsync(orderQueueMessage);
    }
    catch (Exception ex)
    {
        log.Info($"Error receiving data: {ex}");

        // handle exception
    }
}