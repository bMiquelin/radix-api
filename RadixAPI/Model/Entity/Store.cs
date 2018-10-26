using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Model.Entity
{
    public class Store : DbEntity<Guid>
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public bool AntiFraud { get; set; }

        public ICollection<StoreGatewayRule> StoreGatewayRules { get; set; }

        public Guid API_KEY { get; set; }
    }
}