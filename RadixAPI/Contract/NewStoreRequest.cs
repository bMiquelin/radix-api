using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class NewStoreRequest
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public bool AntiFraud { get; set; }

        public ICollection<StoreGatewayRuleRequest> StoreGatewayRules { get; set; }
    }
}
