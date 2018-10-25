﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class CreditCardTransactionModel
    {
        /// <summary>
        /// Valor da transação em centavos. R$ 100,00 = 10000
        /// </summary>
        [Required]
        public int AmountInCents { get; set; }

        [Required]
        public CreditCardModel MyProperty { get; set; }

        /// <summary>
        /// Número de Parcelas
        /// </summary>
        public int InstallmentCount { get; set; }
    }
}