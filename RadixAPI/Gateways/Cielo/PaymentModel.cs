using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Cielo
{
    public class PaymentModel
    {
        /// <summary>
        /// Tipo do Meio de Pagamento.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Valor do Pedido (ser enviado em centavos).
        /// </summary>
        [MaxLength(15)]
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// Moeda na qual o pagamento será feito (BRL).
        /// </summary>
        [MaxLength(3)]
        public string Currency { get; set; }

        /// <summary>
        /// Pais na qual o pagamento será feito.
        /// </summary>
        [MaxLength(3)]
        public string Country { get; set; }

        /// <summary>
        /// Define comportamento do meio de pagamento (ver Anexo)/NÃO OBRIGATÓRIO PARA CRÉDITO.
        /// </summary>
        [MaxLength(15)]
        public string Provider { get; set; }

        /// <summary>
        /// https://developercielo.github.io/manual/cielo-ecommerce#service-tax-amount-taxa-de-embarque
        /// </summary>
        [MaxLength(15)]
        public int ServiceTaxAmount { get; set; }

        /// <summary>
        /// Texto impresso na fatura bancaria comprador - Exclusivo para VISA/MASTER - não permite caracteres especiais - Ver Anexo
        /// </summary>
        [MaxLength(13)]
        [Required]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// Número de Parcelas.
        /// </summary>
        [MaxLength(2)]
        [Required]
        public int Installments { get; set; }

        /// <summary>
        /// Tipo de parcelamento - Loja (ByMerchant) ou Cartão (ByIssuer).
        /// </summary>
        [MaxLength(10)]
        public string Interest { get; set; }

        /// <summary>
        /// Booleano que identifica que a autorização deve ser com captura automática.
        /// </summary>
        public bool Capture { get; set; }

        /// <summary>
        /// Define se o comprador será direcionado ao Banco emissor para autenticação do cartão
        /// </summary>
        public bool Authenticate { get; set; }
    }
}
