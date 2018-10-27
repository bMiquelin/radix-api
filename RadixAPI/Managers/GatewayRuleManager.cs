using RadixAPI.Providers;
using RadixAPI.Model.Entity;
using System;
using System.Collections.Generic;
using RadixAPI.Exceptions;

namespace RadixAPI.Managers
{
    public class ProviderRuleManager
    {
        public static ProviderEnum PickProvider(string brand, IEnumerable<StoreProviderRule> rules)
        {
            foreach(var rule in rules)
            {
                if (string.IsNullOrWhiteSpace(rule.Brand)
                    ||
                    brand.Equals(rule.Brand, StringComparison.InvariantCultureIgnoreCase))
                    return rule.Provider;
            }
            throw new StoreException("No provider rules defined for the store");
        }
    }
}
