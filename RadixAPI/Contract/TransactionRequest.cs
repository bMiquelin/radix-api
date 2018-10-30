using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class TransactionRequest
    {
        [Required]
        public CreditCard CreditCard { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public CustomerData ShippingData { get; set; }

        [Required]
        public CustomerData BillingData { get; set; }

        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public Guid TransactionId { get; set; }

        [JsonIgnore]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Texto impresso na fatura bancaria comprador
        /// </summary>
        [MaxLength(13)]
        [Required]
        public string Descriptor { get; set; }
    }
}
