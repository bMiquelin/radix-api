using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class CreditCardModel
    {
        /// <summary>
        /// Bandeira do cartão do cliente
        /// </summary>
        [Required]
        public string CreditCardBrand { get; set; }

        /// <summary>
        /// Número do cartão do cliente. Informar apenas números.
        /// </summary>
        [Required]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Mês de expiração do cartão
        /// </summary>
        [Required]
        public int ExpMonth { get; set; }

        /// <summary>
        /// Ano de expiração do cartão
        /// </summary>
        [Required]
        public int ExpYear { get; set; }

        /// <summary>
        /// Código de segurança do cartão
        /// </summary>
        public int SecurityCode { get; set; }

        /// <summary>
        /// Nome do portador do cartão
        /// </summary>
        [Required]
        public string HolderName { get; set; }
    }
}
