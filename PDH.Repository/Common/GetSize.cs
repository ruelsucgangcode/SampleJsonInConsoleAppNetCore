using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Repository.Common
{
    public static class GetSize
    {
        public static string PizzaSize(int code)
        {
            switch (code)
            {
                case 1:
                    return "Too Small";
                    break;
                case 2:
                    return "Just right";
                    break;
                case 3:
                    return "You might puke";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}