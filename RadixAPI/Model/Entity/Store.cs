using System;
using System.Collections.Generic;

namespace RadixAPI.Model.Entity
{
    public class Store : DbEntity<Guid>
    {

        public bool AntiFraud { get; set; }

        public ICollection<StoreGatewayRule> StoreGatewayRules { get; set; }

        public string API_KEY { get; set; }
    }
}