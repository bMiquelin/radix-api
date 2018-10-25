using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Model.Entity
{
    public class StoreGatewayRule
    {
        [Required]
        public Store Store { get; set; }

        /// <summary>
        /// CreditCard brand (Visa / Master / Amex / Elo / Aura / JCB / Diners / Discover / Hipercard)
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string Brand { get; set; }

        [Required]
        public Gateways.GatewayEnum Gateway { get; set; }
    }
}
