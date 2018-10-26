using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class StoreGatewayRuleRequest
    {
        [MaxLength(10)]
        public string Brand { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public Gateways.GatewayEnum Gateway { get; set; }
    }
}
