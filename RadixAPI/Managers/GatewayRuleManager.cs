using RadixAPI.Gateways;
using RadixAPI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Managers
{
    public class GatewayRuleManager
    {
        public static IGateway PickGateway(string brand, IEnumerable<StoreGatewayRule> rules)
        {
            foreach(var rule in rules)
            {
                if (string.IsNullOrWhiteSpace(rule.Brand)
                    ||
                    brand.Equals(rule.Brand, StringComparison.InvariantCultureIgnoreCase))
                    return GatewayIterator.GetGateway(rule.Gateway);
            }
            return null;
        }
    }
}
