using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class CustomerPhone
    {
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
