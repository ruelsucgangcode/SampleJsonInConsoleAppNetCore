using Microsoft.Extensions.DependencyInjection;
using PDH.Models.DTO;
using PDH.Repository.Infastructure;
using PDH.Services.Infastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PDH.Repository.Common;

namespace PDH
{
    public class CreateOrderService : iCreateOrderService
    {
        public async Task<bool> CreateOrder(List<OrdersDTO> oList)
        {
            var _serviceProvider = ServiceContainer.ConfigurePizza();
            var serviceObj = _serviceProvider.GetService<iOrdersProvider>();

            await serviceObj.CreateOrder(oList);
            return true;
        }
    }
}
