using System;
using System.Collections.Generic;
using System.Text;

namespace PDH.Repository.Common
{
    public static class MenuItems
    {
        public static string[] PopulateMenuItems()
        {
            string[] arrMenu = { "[1] Create Order", "[2] Deliver Order", "[3] Exit" };
            return arrMenu;    
        }
    }
}
