using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Providers.Stone
{
    public class CreditCardTransactionModel
    {
        /// <summary>
        /// Valor da transação em centavos. R$ 100,00 = 10000
        /// </summary>
        [Required]
        public int AmountInCents { get; set; }

        [Required]
        public CreditCardModel CreditCard { get; set; }

        /// <summary>
        /// Número de Parcelas
        /// </summary>
        public int InstallmentCount { get; set; }
    }
}
