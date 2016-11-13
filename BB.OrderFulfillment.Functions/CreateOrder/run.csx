public static async Task Run(
    HttpRequestMessage req,
    IAsyncCollector<string> ordersQueue,
    TraceWriter log)
{
    string rawOrder = await req.Content.ReadAsStringAsync();
    log.Info($"Received new order: {rawOrder}");

    try
    {
        await ordersQueue.AddAsync(rawOrder);

        log.Info($"Successfully enqueued order");
    }
    catch (Exception ex)
    {
        log.Info($"Error receiving data: {ex}");

        // handle exception for further processing. consider handling different exceptions separately,
        // where some might cause retries (as thrown exceptions, which will cause a requeue) and others 
        // might store poisonous messages to a new {queueName}-error queue
    }
}