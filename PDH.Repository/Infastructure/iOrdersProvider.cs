using PDH.Models.Domain;
using PDH.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository.Infastructure
{
    public interface iOrdersProvider
    {
        Task<bool> CreateOrder(List<OrdersDTO> customerOrder);   
    }
}
