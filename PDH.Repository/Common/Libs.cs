using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PDH.Repository.Common
{
    public static class Libs
    {
        public static string Getinfo (int id)
        {
           ResourceManager rm = new ResourceManager("PDH.Repository.resources",
            Assembly.GetExecutingAssembly());
            switch (id)
            {
                case 1:
                    return   rm.GetString("fileid");
                    break;
                case 2:
                    return rm.GetString("header");
                    break;
                case 3:
                    return rm.GetString("subheader1");
                    break;
                case 4:
                    return rm.GetString("selectmenu");
                    break;
                case 5:
                    return rm.GetString("enterorderdetails"); 
                    break;
                case 6:
                    return rm.GetString("createpizzaorder");
                    break;
                case 7:
                    return rm.GetString("pizzanames");  
                case 8:
                    return rm.GetString("pizzasizes");
                    break;
                case 9:
                    return rm.GetString("orderdelivery");
                    break;
                case 10:
                    return rm.GetString("followformat1");
                    break;
                case 11:
                    return rm.GetString("eg1");
                    break;
                case 12:
                    return rm.GetString("followformat2");
                    break;
                case 13:
                    return rm.GetString("hitenter");
                    break;
                case 14:
                    return rm.GetString("entercust");
                    break;
                case 15:
                    return rm.GetString("enterloc");
                    break;
                case 16:
                    return rm.GetString("enterord");
                    break;
                case 17:
                    return rm.GetString("yourordare");
                    break ;
                case 18:
                    return rm.GetString("genId");
                    break;
                case 19:
                    return rm.GetString("receipts");
                    break;
                case 20:
                    return rm.GetString("delto");
                    break;
                case 21:
                    return rm.GetString("oid");
                    break;
                case 22:
                    return rm.GetString("nm");
                    break;
                case 23:
                    return rm.GetString("hno");
                    break;
                case 24:
                    return rm.GetString("df");
                    break;
                case 25:
                    return rm.GetString("od");
                    break;
                case 26:
                    return rm.GetString("piz");
                    break;
                case 27:
                    return rm.GetString("sz");
                    break;
                case 28:
                    return rm.GetString("prc");
                    break;
                case 29:
                    return rm.GetString("tot");
                    break;
                case 30:
                    return rm.GetString("");
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
