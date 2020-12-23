using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Repository.Common
{
    public static class GetPrice
    {
    public static double GetItemPrice(string Pizza, string Size)
        {
            double _price = 0;
            switch (Size.ToLower().Trim())
            {
                case "too small":   
                    _price = GetPriceByPizzaName(Pizza.ToLower().Trim());
                    break;
                case "just right":
                    _price = 1.5 * GetPriceByPizzaName(Pizza.ToLower().Trim()) ;
                    break;
                case "you might puke":
                    _price = (4 * GetPriceByPizzaName(Pizza.ToLower().Trim())) ;
                    break;
                default:
                    _price = 0;
                    break;
            }
            return _price ;
        }

        public static double GetDeliveryCharge(string HouseNumber)
        {
            // get delivery charge
            var c = HouseNumber.Substring(0, 1);
            const string _loc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double deliveryCharge = _loc.IndexOf(c.ToUpper()) + 1;
            return deliveryCharge; 
        }

        private static double GetPriceByPizzaName(string pizza)
        {
            double _price = 0;
            switch (pizza.ToLower().Trim())
            {
                case "all chiz":
                    _price = 75;
                    break;
                case "pepperonli":
                    _price = 99.95;
                    break;
                case "hawayan":
                    _price = 110.25;
                    break;
                default:
                    _price = 0;
                    break;
            }
            return _price;
        }
    }
}
