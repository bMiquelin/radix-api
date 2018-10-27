using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class TransactionRequest
    {
        [Required]
        public CreditCard CreditCard { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
