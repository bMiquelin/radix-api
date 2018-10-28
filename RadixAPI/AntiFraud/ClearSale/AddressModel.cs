using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class AddressModel
    {
        public string Street { get; set; }

        /// <summary>
        /// City (No abbreviations)
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [MaxLength(2)]
        [Required]
        public string State { get; set; }

        public string Comp { get; set; }

        /// <summary>
        /// Zip Code
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Country (No abbreviations)
        /// </summary>
        /// 
        [MaxLength(150)]
        public string Country { get; set; }

        public string Number { get; set; }
    }
}
