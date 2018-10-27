using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class NewStoreRequest
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public bool AntiFraud { get; set; }

        [Required]
        public ICollection<StoreProviderRuleRequest> StoreProviderRules { get; set; }
    }
}
