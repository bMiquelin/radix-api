using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Helper
{
    public class CreditCardHelper
    {
        /// <returns>Item1: Month, Item2: Year</returns>
        public static Tuple<int, int> GetExpMonthAndYear(string expDate)
        {
            var splitExpDate = expDate.Split("/");
            var expMonth = splitExpDate[0];
            var expYear = splitExpDate[1];
            return new Tuple<int, int>(int.Parse(expMonth), int.Parse(expYear));
        }
    }
}
