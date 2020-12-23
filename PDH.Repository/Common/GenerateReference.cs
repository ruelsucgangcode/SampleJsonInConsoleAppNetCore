
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDH.Repository.Common
{
    public static class GenerateReference 
    {
        public static async Task<string> CreateOrderId()
        {
            string Id = GetRndId(5);
            return  Id; 
        }

        #region
        // create the  auto generated id  ( this is just a simple generation of id )
        private static Random rndLetter = new Random();
        private static string GetRndId(int length)
        {  
            string m = DateTime.Now.Month.ToString().Substring(0, 2);
            string d = DateTime.Now.Day.ToString();
            string h = DateTime.Now.Hour.ToString();
            string mm = DateTime.Now.Minute.ToString();
            string ms = DateTime.Now.Second.ToString();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rndLetter.Next(s.Length)]).ToArray()) + m + d + h + mm+ ms ;
        }
        #endregion
    }
}
