using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PDH.Models.Domain;
using PDH.Models.DTO;
using PDH.Repository.Common;
using PDH.Repository.Infastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository
{
    public class DeliveryProvider : iDeliveryProvider
    {
        public async Task<List<OrdersDTO>> GetOrder(string orderId)
        {
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string JsonData = GetDirectory + Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.FileId)); ;

            try
            {
                string jsonString = "";
                using (var reader = new StreamReader(JsonData))
                {
                    jsonString = reader.ReadToEnd();
                    jsonString = jsonString.Replace("order id", "orderid");
                    jsonString = jsonString.Replace("quarantine house number", "housenumber");
                    List<OrdersDTO> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrdersDTO>>(jsonString);
                    var obj = from x in result where x.OrderId.ToUpper()==orderId.ToUpper()
                              select new
                              {
                                  orderId = x.OrderId,
                                  Name = x.Name,
                                  HouseNumber = x.HouseNumber,
                                  Pizza = x.Pizza,
                                  Size = x.Size,
                                  Price = x.Price                              };
                    return result.Where(x => x.OrderId.ToUpper()==orderId.ToUpper()).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
