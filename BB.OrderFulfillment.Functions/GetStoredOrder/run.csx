#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"
#r "../bin/BB.OrderFulfillment.Domain.dll"
#r "../bin/BB.OrderFulfillment.Orders.dll"

using System.Net;
using Newtonsoft.Json;
using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.StorageModels;

public static async Task<HttpResponseMessage> Run(
    HttpRequestMessage req,
    OrderEntity orderEntity,
    TraceWriter log)
{
    Order order = JsonConvert.DeserializeObject<Order>(orderEntity.SerializedOrder);

    log.Info(order.ToString());

    return req.CreateResponse(HttpStatusCode.OK, order);
}