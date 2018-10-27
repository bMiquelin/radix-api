using System.Collections.ObjectModel;

namespace RadixAPI.Providers.Stone
{
    public class SaleRequestModel
    {
        public Collection<CreditCardTransactionModel> CreditCardTransactionCollection { get; set; }

        public OrderModel Order { get; set; }
    }
}
