using AutoMapper;
using BB.OrderFulfillment.Domain.Models;
using BB.OrderFulfillment.Orders.ExternalModels;

namespace BB.OrderFulfillment.Orders.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            base.CreateMap<ECommerceOrder, Order>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.OrderNumber.ToString()))
                .ForMember(dest => dest.CustomerName, o => o.MapFrom(src => src.Customer))
                .ForMember(dest => dest.CustomerAddress, o => o.MapFrom(src => src.ShipToAddress))
                .ForMember(dest => dest.Skus, o => o.MapFrom(src => src.SoldItems));

            base.CreateMap<ECommerceSku, Sku>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Sku))
                .ForMember(dest => dest.Price, o => o.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, o => o.MapFrom(src => src.Quantity));
        }
    }
}
