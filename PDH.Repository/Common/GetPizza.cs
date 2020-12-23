using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Repository.Common
{
    public static class GetPizza
    {
        public static string PizzaName(int code)
        {
            switch (code)
            {
                case 1:
                    return "All Chiz";
                    break;
                case 2:
                    return "Pepperonli";
                    break;
                case 3:
                    return "Hawayan";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
