using System;
using System.Collections.Generic;

namespace RadixAPI.Model.Entity
{
    public class Store : DbEntity<Guid>
    {
        public string Name { get; set; }
        public bool AntiFraud { get; set; }

        public ICollection<StoreGatewayRule> StoreGatewayRules { get; set; }

        public Guid API_KEY { get; set; }
    }
}