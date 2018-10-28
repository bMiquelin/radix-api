using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Providers.Cielo
{
    public class CustomerAddressModel
    {
        /// <summary>
        /// Endereço do Comprador.
        /// </summary>
        [MaxLength(255)]
        public string Street { get; set; }

        /// <summary>
        /// Número do endereço do Comprador.
        /// </summary>
        [MaxLength(15)]
        public string Number { get; set; }

        /// <summary>
        /// Complemento do endereço do Comprador.
        /// </summary>
        [MaxLength(50)]
        public string Complement { get; set; }

        /// <summary>
        /// CEP do endereço do Comprador.
        /// </summary>
        [MaxLength(9)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Cidade do endereço do Comprador.
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Estado do endereço do Comprador.
        /// </summary>
        [MaxLength(2)]
        public string State { get; set; }

        /// <summary>
        /// Pais do endereço do Comprador.
        /// </summary>
        [MaxLength(35)]
        public string Country { get; set; }
    }
}
