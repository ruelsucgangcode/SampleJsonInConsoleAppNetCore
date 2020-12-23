using Microsoft.Extensions.DependencyInjection;
using PDH.Repository;
using PDH.Repository.Infastructure;
using PDH.Services.Infastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDH
{
    public static class ServiceContainer
    {

        // Handles  the dependency injection..
       public static ServiceProvider ConfigurePizza()
        {
            return new ServiceCollection()
            .AddScoped<iOrdersProvider, OrdersProvider>()
            .AddScoped<iDeliveryProvider, DeliveryProvider>()

            .AddScoped<iAppService, AppService>()
            .AddScoped<iDeliverPizzaService, DeliverPizzaService>()
            .AddScoped<iCreateOrderService, CreateOrderService>()
            .BuildServiceProvider();
        }
    }
}


