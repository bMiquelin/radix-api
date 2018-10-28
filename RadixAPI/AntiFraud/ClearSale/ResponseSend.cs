using System.Collections.ObjectModel;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class ResponseSend
    {
        public Collection<OrderStatusModel> Orders { get; set; }

        public string TransactionId { get; set; }
    }
}
