using RadixAPI.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class StoreProviderRuleRequest
    {
        [MaxLength(10)]
        public string Brand { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public ProviderEnum Provider { get; set; }
    }
}
