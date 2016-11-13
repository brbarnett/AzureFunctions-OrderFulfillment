using System.Collections.Generic;
using BB.OrderFulfillment.Orders.ExternalModels;
using BB.OrderFulfillment.Orders.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BB.OrderFulfillment.Tests
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void DeserializeExternalModel()
        {
            string rawOrder = "{ \"orderNumber\": \"12345\", \"customer\": \"Jane Doe\", \"shipToAddress\": \"123 Main St, Anytown, NY, 12345\", \"soldItems\": [ { \"sku\": \"AA-4910\", \"itemName\": \"Widget\", \"price\": 9.99, \"quantity\": 2 } ] }";

            JsonConvert.DeserializeObject<ECommerceOrder>(rawOrder);
        }

        [TestMethod]
        public void MapExternalModelToDomain()
        {
            ECommerceOrder externalModel = new ECommerceOrder
            {
                OrderNumber = 12345,
                Customer = "Jane Doe",
                ShipToAddress = "123 Main St, Anytown, NY, 12345",
                SoldItems = new List<ECommerceSku>
                {
                    new ECommerceSku
                    {
                        Sku = "AA-4910",
                        ItemName = "Widget",
                        Price = 9.99m,
                        Quantity = 2
                    }
                }
            };

            IOrderMapper mapper = new OrderMapper();
            mapper.Map(externalModel);
        }
    }
}
