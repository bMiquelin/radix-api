using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class TransactionRequest
    {
        public CreditCard CreditCard { get; set; }
        public int Amount { get; set; }
    }
}
