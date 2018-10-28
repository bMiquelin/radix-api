using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class PhoneModel
    {
        /// <summary>
        /// Telephone Type
        /// </summary>
        [Required]
        public TelephoneTypeEnum Type { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        public int CountryCode { get; set; }

        /// <summary>
        /// Area Code
        /// </summary>
        [Required]
        public int AreaCode { get; set; }

        /// <summary>
        /// Telephone Number
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string Number { get; set; }
    }
}
