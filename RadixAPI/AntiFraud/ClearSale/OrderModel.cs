using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class OrderModel
    {
        /// <summary>
        /// Order Identification Code
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// Order Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Order e-Mail
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Sum of Items Values
        /// </summary>
        [Required]
        public int TotalItems { get; set; }

        /// <summary>
        /// Order total Value
        /// </summary>
        [Required]
        public int TotalOrder { get; set; }

        /// <summary>
        /// Shipping Value
        /// </summary>
        [Required]
        public int TotalShipping { get; set; }

        /// <summary>
        /// Order originating IP address
        /// </summary>
        [Required]
        public string IP { get; set; }

        /// <summary>
        /// Order currency
        /// Brazilian Real = BRL = 986
        /// </summary>
        [Required]
        public string Currency { get; set; }

        /// <summary>
        /// Payment Data
        /// </summary>
        [Required]
        public Collection<PaymentModel> Payments { get; set; }

        /// <summary>
        /// Billing Data
        /// </summary>
        [Required]
        public PersonModel BillingData { get; set; }

        /// <summary>
        /// Shipping Data
        /// </summary>
        [Required]
        public PersonModel ShippingData { get; set; }

        /// <summary>
        /// Order Items	Order Items
        /// </summary>
        [Required]
        public Collection<ItemModel> Items { get; set; }

        /// <summary>
        /// Order source
        /// </summary>
        [Required]
        public string Origin { get; set; }
    }
}
