
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PDH.Models.DTO;
using PDH.Repository.Common;
using PDH.Repository.Infastructure;
using PDH.Services.Infastructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PDH
{
    public class AppService : iAppService
    {
        public async Task  GetOption(int mnuSelected)
        {
            var _serviceProvider = ServiceContainer.ConfigurePizza();
            switch (mnuSelected)
            {
                case 1:
                    var createOrderServiceObj = _serviceProvider.GetService<iCreateOrderService>();

                    // create order details:
                    List<OrdersDTO> oList = new List<OrdersDTO>();
                    oList = await TextLabels.PrintCreateOrder();

                    await  createOrderServiceObj.CreateOrder(oList);
                    Console.ReadLine();
                    break;
                case 2:
                    var deliveryServiceObj = _serviceProvider.GetService<iDeliverPizzaService>();
                    ResponseDTO obj = new ResponseDTO();
                    obj = await deliveryServiceObj.DeliverPizza();

                    // print the order details:
                    TextLabels.PrintCustomerOrders(obj);
                    Console.ReadLine();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You selected option the default");
                    break;
            }
        }
    
    }
}
