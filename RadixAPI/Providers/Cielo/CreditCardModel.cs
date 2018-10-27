using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Providers.Cielo
{
    public class CreditCardModel
    {
        /// <summary>
        /// Número do Cartão do Comprador.
        /// </summary>
        [MaxLength(19)]
        [Required]  
        public string CardNumber { get; set; }

        /// <summary>
        /// Nome do Comprador impresso no cartão.
        /// </summary>
        [MaxLength(25)]
        [Required]
        public string Holder { get; set; }

        /// <summary>
        /// Data de validade impresso no cartão.
        /// </summary>
        [MaxLength(7)]
        [Required]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Código de segurança impresso no verso do cartão - Ver Anexo.
        /// </summary>
        [MaxLength(4)]
        [Required]
        public string SecurityCode { get; set; }

        /// <summary>
        /// Booleano que identifica se o cartão será salvo para gerar o CardToken.
        /// </summary>
        public bool SaveCard { get; set; }

        /// <summary>
        /// Bandeira do cartão (Visa / Master / Amex / Elo / Aura / JCB / Diners / Discover / Hipercard).
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string Brand { get; set; }
    }
}
