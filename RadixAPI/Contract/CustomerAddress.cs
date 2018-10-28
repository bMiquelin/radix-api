using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Contract
{
    public class CustomerAddress
    {
        [MaxLength(150)]
        public string City { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }

        [MaxLength(150)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
