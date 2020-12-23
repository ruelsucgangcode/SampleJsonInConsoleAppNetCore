using PDH.Models.Domain;
using PDH.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository.Infastructure
{
    public interface iDeliveryProvider
    {
        Task<List<OrdersDTO>> GetOrder(string orderId);   
    }
}
