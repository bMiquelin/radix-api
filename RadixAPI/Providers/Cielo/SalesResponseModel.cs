using System;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Providers.Cielo
{
    public class SalesResponseModel
    {
        /// <summary>
        /// Número da autorização, identico ao NSU.	
        /// </summary>
        [MaxLength(6)]
        public string ProofOfSale { get; set; }

        /// <summary>
        /// Id da transação na adquirente.	
        /// </summary>
        [MaxLength(20)]
        public string Tid { get; set; }

        /// <summary>
        /// Código de autorização.	
        /// </summary>
        [MaxLength(6)]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Texto que será impresso na fatura bancaria do portador - Disponivel apenas para VISA/MASTER - nao permite caracteres especiais	
        /// </summary>
        [MaxLength(13)]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// Campo Identificador do Pedido.	
        /// </summary>
        [MaxLength(36)]
        public Guid PaymentId { get; set; }

        /// <summary>
        /// Eletronic Commerce Indicator. Representa o quão segura é uma transação.	
        /// </summary>
        [MaxLength(2)]
        public string ECI { get; set; }

        /// <summary>
        /// Status da Transação.	
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Código de retorno da Adquirência.	
        /// </summary>
        [MaxLength(32)]
        public string ReturnCode { get; set; }

        /// <summary>
        /// Mensagem de retorno da Adquirência.	
        /// </summary>
        [MaxLength(512)]
        public string ReturnMessage { get; set; }
    }
}
