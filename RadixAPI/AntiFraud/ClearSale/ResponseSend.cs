using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class ResponseSend
    {
        public List<OrderStatusModel> Orders { get; set; }

        public string TransactionId { get; set; }
    }
}
