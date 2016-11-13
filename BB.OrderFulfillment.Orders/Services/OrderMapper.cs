using AutoMapper;
using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.ExternalModels;
using BB.OrderFulfillment.Orders.MappingProfiles;

namespace BB.OrderFulfillment.Orders.Services
{
    public class OrderMapper : IOrderMapper
    {
        private readonly IMapper _mapper;

        public OrderMapper()
        {
            // configure automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderProfile>();
            });
            config.AssertConfigurationIsValid();

            this._mapper = config.CreateMapper();
        }

        public Order Map(ECommerceOrder externalModel)
        {
            return this._mapper.Map<ECommerceOrder, Order>(externalModel);
        }
    }
}
