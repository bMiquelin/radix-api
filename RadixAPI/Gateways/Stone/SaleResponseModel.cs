using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class SaleResponseModel
    {
        public object ErrorReport { get; set; }
        public int InternalTime { get; set; }
        public string MerchantKey { get; set; }
        public string RequestKey { get; set; }
        public List<object> BoletoTransactionResultCollection { get; set; }
        public string BuyerKey { get; set; }
        public List<CreditCardTransactionResultModel> CreditCardTransactionResultCollection { get; set; }
        public OrderResultModel OrderResult { get; set; }
    }
}
