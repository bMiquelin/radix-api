using System;
using System.ComponentModel.DataAnnotations;
namespace RadixAPI.Providers.Cielo
{
    public class SalesRequestModel
    {
        /// <summary>
        /// Identificador da loja na Cielo.
        /// </summary>
        [MaxLength(36)]
        [Required]
        public Guid MerchantId { get; set; }

        /// <summary>
        /// Chave Publica para Autenticação Dupla na Cielo.
        /// </summary>
        [MaxLength(40)]
        [Required]
        public string MerchantKey { get; set; }

        /// <summary>
        /// Identificador do Request, utilizado quando o lojista usa diferentes servidores para cada GET/POST/PUT.
        /// </summary>
        [MaxLength(36)]
        [Required]
        public Guid RequestId { get; set; }

        /// <summary>
        /// Numero de identificação do Pedido.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string MerchantOrderId { get; set; }

        [Required]
        public CustomerModel Customer { get; set; }

        [Required]
        public PaymentModel Payment { get; set; }

        [Required]
        public CreditCardModel CreditCard { get; set; }
    }
}
