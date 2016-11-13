using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.ExternalModels;

namespace BB.OrderFulfillment.Orders.Services
{
    public interface IOrderMapper
    {
        Order Map(ECommerceOrder externalModel);
    }
}
