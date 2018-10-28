using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class PersonModel
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Person or Company
        /// </summary>
        [Required]
        public PersonTypeEnum Type { get; set; }

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
        public AddressModel Address { get; set; }

        [Required]
        public Collection<PhoneModel> Phones { get; set; }
    }
}
