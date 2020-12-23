using PDH.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Models.DTO
{
    public class ResponseDTO
    {
        public string OrderId { get; set; }
        public List<OrdersDTO> OrderList { get; set; }   
    }
}
