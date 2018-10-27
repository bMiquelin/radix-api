using System;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Providers.Cielo
{
    public class CustomerModel
    {
        /// <summary>
        /// Nome do Comprador.
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Status de cadastro do comprador na loja (NEW / EXISTING)
        /// </summary>
        [MaxLength(255)]
        public string Status { get; set; }

        /// <summary>
        /// Número do RG, CPF ou CNPJ do Cliente.
        /// </summary>
        [MaxLength(14)]
        public string Identity { get; set; }

        /// <summary>
        /// Tipo de documento de identificação do comprador (CFP/CNPJ).
        /// </summary>
        [MaxLength(255)]
        public string IdentityType { get; set; }

        /// <summary>
        /// Email do Comprador.
        /// </summary>
        [MaxLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Data de nascimento do Comprador.
        /// </summary>
        [MaxLength(10)]
        public DateTime Birthdate { get; set; }

        public CustomerAddressModel Address { get; set; }
        public CustomerDeliveryAddressModel DeliveryAddress { get; set; }
    }
}
