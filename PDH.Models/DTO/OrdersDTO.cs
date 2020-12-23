using PDH.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Models.DTO
{
    public class OrdersDTO
    {
        public string OrderId { get; set; }
        public string Pizza { get; set; } 
        public string Size { get; set; }
        public string HouseNumber { get; set; }
        public string Name { get; set; }  

        public decimal Price { get; set; }
        public decimal DeliveryCharge { get; set; }

    }
}   
