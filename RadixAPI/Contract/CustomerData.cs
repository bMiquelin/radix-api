using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class CustomerData
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Customer Email
        /// </summary>
        [MaxLength(150)]
        public string Email { get; set; }

        /// <summary>
        /// Gender
        /// M = Male
        /// F = Female
        /// </summary>
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required]
        public CustomerAddress Address { get; set; }

        [Required]
        public Collection<CustomerPhone> Phones { get; set; }
    }
}
