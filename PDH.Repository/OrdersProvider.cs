using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PDH.Models.Domain;
using PDH.Models.DTO;
using PDH.Repository.Common;
using PDH.Repository.Infastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository
{
    public class OrdersProvider : iOrdersProvider
    {
        public async Task<bool> CreateOrder(List<OrdersDTO> customerOrder)
        {
            try
            {
                var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string JsonData = GetDirectory + Libs.Getinfo(Convert.ToInt32(ResourceEnum.ResourceCode.FileId)); ;

                JObject data2append = null;
                foreach (var item in customerOrder)
                {
                    string text = File.ReadAllText(JsonData);
                    text = text.Replace("]", "");
                    File.WriteAllText(JsonData, text);
                    data2append = new JObject(
                    new JProperty("order id", item.OrderId),
                    new JProperty("pizza", item.Pizza),
                    new JProperty("size", item.Size),
                    new JProperty("quarantine house number", item.HouseNumber),
                    new JProperty("name", item.Name));
                    await File.AppendAllTextAsync(JsonData, "," + data2append.ToString() + "]");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
