using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RadixAPI.Providers.Stone
{
    public class SaleResponseModel
    {
        public object ErrorReport { get; set; }
        public int InternalTime { get; set; }
        public string MerchantKey { get; set; }
        public string RequestKey { get; set; }
        public Collection<object> BoletoTransactionResultCollection { get; set; }
        public string BuyerKey { get; set; }
        public Collection<CreditCardTransactionResultModel> CreditCardTransactionResultCollection { get; set; }
        public OrderResultModel OrderResult { get; set; }
    }
}
