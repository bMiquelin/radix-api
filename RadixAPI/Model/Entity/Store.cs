using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RadixAPI.Model.Entity
{
    public class Store : DbEntity<Guid>
    {
        [MaxLength(255)]
        public string Name { get; set; }
        
        public bool AntiFraud { get; set; }

        public ICollection<StoreProviderRule> StoreProviderRules { get; set; }

        [JsonIgnore]
        public Guid API_KEY { get; set; }
    }
}