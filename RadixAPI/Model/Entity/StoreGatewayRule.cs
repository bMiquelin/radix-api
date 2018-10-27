using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RadixAPI.Providers;

namespace RadixAPI.Model.Entity
{
    public class StoreProviderRule : DbEntity<int>
    {
        [Required]
        public Store Store { get; set; }

        /// <summary>
        /// CreditCard brand (Visa / Master / Amex / Elo / Aura / JCB / Diners / Discover / Hipercard)
        /// </summary>
        [MaxLength(10)]
        public string Brand { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public ProviderEnum Provider { get; set; }
    }
}
