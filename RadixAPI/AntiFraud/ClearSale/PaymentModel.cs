using System;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class PaymentModel
    {
        /// <summary>
        /// Payment Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Payment Value
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Payment Type
        /// </summary>
        [Required]
        public PaymentTypeEnum Type { get; set; }

        /// <summary>
        /// Credit Card Number
        /// </summary>
        [MaxLength(200)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit Card Holder
        /// </summary>
        [MaxLength(150)]
        public string CardHolderName { get; set; }

        /// <summary>
        /// Expiration Date
        /// </summary>
        [MaxLength(50)]
        public string CardExpirationDate { get; set; }
         
        /// <summary>
        /// Credit Card
        /// </summary>
        public CreditCardTypeEnum CardType { get; set; }

        /// <summary>
        /// Credit Card BIN (first 6 digits)
        /// </summary>
        [MaxLength(6)]
        public string CardBin { get; set; }

        public int PaymentTypeId { get; set; }
    }
}
