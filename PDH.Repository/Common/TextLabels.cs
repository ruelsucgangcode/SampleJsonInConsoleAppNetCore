using PDH.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository.Common
{
    public static class TextLabels
    {
        public static void PrintHeader(string subTxt)
        {
            string txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.HeaderText));
            lineBreak("*"); lineBreak(" ");
            Console.WriteLine(displaycText(txt));
            TextLabels.SubHeader(subTxt);
            lineBreak(" "); lineBreak("*");
        }
        public static void MainMenu()
        {
            string[] arrMenu = MenuItems.PopulateMenuItems();
            lineBreak(" ");
            foreach (var item in arrMenu)
            {
                Console.WriteLine(displaylText(item));
            }
            lineBreak("-");
        }
        public static void SubHeader(string txt)
        {
            Console.WriteLine(displaycText(txt));
        }

        public static string SelectMenu()
        {
            return displaycText(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.SelectMenu)));
        }

        public static string Delivery()
        {
            string txt1 = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.EnterOrderDetails));
            lineBreak(" ");
            string val;
            Console.Write(displaycText(txt1));
            val = Console.ReadLine();
            string orderId = val;
            return orderId;
        }
        public static string DeliveryMenu()
        {
            clearScn();
            PrintHeader(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.OrderDelivery)));
            string _orderId = Delivery();
            return _orderId;
        }

        #region Create Order(s)
        public static async Task<List<OrdersDTO>> PrintCreateOrder()
        {
            string txt = ""; char c = ' '; string _order = ""; string _orders = ""; string orderId = "";
            List<OrdersDTO> oList = new List<OrdersDTO>();
            OrdersDTO oItem = null;

            clearScn();
            TextLabels.PrintHeader(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.CreatePizzaOrder)));

            // display the code
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.PizzaNames));
            Console.WriteLine(displaycText(txt));
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.PizzaSizes));
            Console.WriteLine(displaycText(txt));
            lineBreak(" ");

            // enter quarantine house number
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.FollowFormat1));
            Console.WriteLine(displaycText(txt));
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Eg1));
            Console.WriteLine(displaycText(txt));
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.FollowFormat2));
            Console.WriteLine(displaycText(txt));
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.HitEnter));
            Console.WriteLine(displaycText(txt));
            lineBreak("=");

            // enter the name
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.EnterCust));
            string name = "";
            Console.Write(displaycText(txt));
            name = Console.ReadLine();

            // enter quarantine house number
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.EnterLoc));
            string housenumber = "";
            Console.Write(displaycText(txt));
            housenumber = Console.ReadLine();

            // enter quarantine house number
            lineBreak(" ");
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.EnterOrd));
            Console.WriteLine(displaycText(txt));
            Console.Write(displaylText(" "));
            _order = Console.ReadLine();

            // compose the string based on the entry order
            string[] orders = _order.Split('/');
            string _pzaname = ""; string _pzasize = "";
            lineBreak(" ");
            orderId = await GenerateReference.CreateOrderId();
            Console.WriteLine(displaycText(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.YourOrdAre))));
            foreach (var o1 in orders)
            {
                string[] items = o1.Split(',');
                _pzaname = GetPizza.PizzaName(Convert.ToInt32(items[0]));
                _pzasize = GetSize.PizzaSize(Convert.ToInt32(items[1]));
                Console.WriteLine(displaylText(_pzaname + "-- " + _pzasize));
                oItem = new OrdersDTO();
                oItem.OrderId = orderId;
                oItem.Name = name;
                oItem.HouseNumber = housenumber;
                oItem.Pizza = _pzaname;
                oItem.Size = _pzasize;
                oList.Add(oItem);
            }
            DisplayOrderId(orderId);
            return oList;
        }

        public static void DisplayOrderId(string orderId)
        {
            // display the generated order id 
            string txt = "";
            lineBreak("=");
            txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.GenId)) + orderId;
            Console.WriteLine(displaycText(txt));
            lineBreak("=");
        }
        #endregion


        #region Order Receipts
        public static void PrintCustomerOrders(ResponseDTO obj)
        {
            try
            {
                string txt = ""; char c = ' ';
                clearScn();
                TextLabels.PrintHeader(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Receipts)));

                Console.WriteLine(displaylText(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.DelTo))));
                txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Oid)) + obj.OrderList[0].OrderId;
                Console.WriteLine(displaylText(txt));

                txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Nm)) + obj.OrderList[0].Name;
                Console.WriteLine(displaylText(txt));

                txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Hno)) + obj.OrderList[0].HouseNumber;
                Console.WriteLine(displaylText(txt));

                double deliveryCharge = GetPrice.GetDeliveryCharge(obj.OrderList[0].HouseNumber);
                txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Df)) + deliveryCharge.ToString();
                Console.WriteLine(displaylText(txt));

                lineBreak(" ");
                double _price = 0;
                double _total = 0;

                lineBreak("-");
                Console.WriteLine(displaylText(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Od))));

                foreach (var item in obj.OrderList)
                {
                    txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Piz)) + item.Pizza;
                    Console.WriteLine(displaylText(txt));
                    txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Sz)) + item.Size;
                    Console.WriteLine(displaylText(txt));
                    _price = GetPrice.GetItemPrice(item.Pizza, item.Size);
                    _total = _total + _price;
                    txt = Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Prc)) + _price.ToString();
                    Console.WriteLine(displaylText(txt));
                    lineBreak(" ");
                }

                if (deliveryCharge <= 0) deliveryCharge = 0;
                _total = _total + deliveryCharge;
                lineBreak("-");
                Console.WriteLine(displaylText(Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.Tot)) + _total.ToString()));
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        private static void lineBreak(string _chr)
        {
            string _lineChr = string.Concat(Enumerable.Repeat(_chr, (Console.WindowWidth) - 6));
            string _line = displaycText(_lineChr);
            Console.WriteLine(_line);
        }
        private static string displaycText(string txt)
        {
            string ret = String.Format("{0," + ((Console.WindowWidth / 2) + (txt.Length / 2)) + "}", txt);
            return ret;
        }
        private static string displaylText(string txt)
        {
            int w = (Console.WindowWidth / 2) - 10;
            string ret = new string(' ', w) + txt;
            return ret;
        }
        private static string displayiText(string txt, int spcLeft)
        {
            int w = (Console.WindowWidth / 2) - spcLeft;
            string ret = new string(' ', w) + txt;
            return ret;
        }
        private static void clearScn()
        {
            Console.Clear();
        }

    }
}
