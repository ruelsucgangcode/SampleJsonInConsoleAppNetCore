using Microsoft.Extensions.DependencyInjection;
using PDH.Models.Domain;
using PDH.Models.DTO;
using PDH.Repository.Common;
using PDH.Repository.Infastructure;
using PDH.Services.Infastructures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDH
{
    public class DeliverPizzaService : iDeliverPizzaService
    {
         public async Task<ResponseDTO> DeliverPizza()
        {
            var _serviceProvider = ServiceContainer.ConfigurePizza();
            ResponseDTO obj = new ResponseDTO();
            obj.OrderId = TextLabels.DeliveryMenu();
            var serviceObj = _serviceProvider.GetService<iDeliveryProvider>();
            obj.OrderList= await serviceObj.GetOrder(obj.OrderId);
            return obj;
        }

    }
}
