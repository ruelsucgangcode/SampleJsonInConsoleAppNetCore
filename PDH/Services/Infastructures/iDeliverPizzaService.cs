using PDH.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Services.Infastructures
{
    public interface iDeliverPizzaService
    {
        Task<ResponseDTO> DeliverPizza();
    }
}
