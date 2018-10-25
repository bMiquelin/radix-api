using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class SaleRequestModel
    {
        public Collection<CreditCardTransactionModel> CreditCardTransactionCollection { get; set; }

        public OrderModel Order { get; set; }
    }
}
