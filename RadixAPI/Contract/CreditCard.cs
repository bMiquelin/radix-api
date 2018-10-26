using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class CreditCard
    {
        [MaxLength(10)]
        public string Brand { get; set; }

        [MaxLength(19)]
        public string CardNumber { get; set; }

        /// <summary>
        /// MM/YY
        /// </summary>
        [MaxLength(7)]
        public string ExpirationDate { get; set; }

        [MaxLength(25)]
        public string Holder { get; set; }

        [MaxLength(4)]
        public string SecurityCode { get; set; }

    }
}
