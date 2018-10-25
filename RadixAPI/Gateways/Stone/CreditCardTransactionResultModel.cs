﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class CreditCardTransactionResult
    {
        public string AcquirerMessage { get; set; }
        public string AcquirerName { get; set; }
        public string AcquirerReturnCode { get; set; }
        public string AffiliationCode { get; set; }
        public int AmountInCents { get; set; }
        public string AuthorizationCode { get; set; }
        public int AuthorizedAmountInCents { get; set; }
        public int CapturedAmountInCents { get; set; }
        public DateTime CapturedDate { get; set; }
        public CreditCardResultModel CreditCard { get; set; }
        public string CreditCardOperation { get; set; }
        public string CreditCardTransactionStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ExternalTime { get; set; }
        public string PaymentMethodName { get; set; }
        public int RefundedAmountInCents { get; set; }
        public bool Success { get; set; }
        public string TransactionIdentifier { get; set; }
        public string TransactionKey { get; set; }
        public string TransactionKeyToAcquirer { get; set; }
        public string TransactionReference { get; set; }
        public string UniqueSequentialNumber { get; set; }
        public int? VoidedAmountInCents { get; set; }
    }
}
