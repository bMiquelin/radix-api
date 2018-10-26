using Microsoft.EntityFrameworkCore;
using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Gateways;
using RadixAPI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Managers
{
    public class TransactionManager
    {
        private readonly RadixAPIContext ctx;
        public TransactionManager(RadixAPIContext ctx)
        {
            this.ctx = ctx;
        }

        public Transaction CreateTransaction(Store store, TransactionRequest transactionRequest)
        {
            var gatewayRules = store.StoreGatewayRules.OrderBy(rule => rule.Priority);
            var gateway = GatewayRuleManager.PickGateway(transactionRequest.CreditCard.Brand, gatewayRules);

            var transaction = ctx.Transactions.Add(new Transaction
            {
                Store = store,
                Date = DateTime.UtcNow,
                Gateway = gateway,
                Brand = transactionRequest.CreditCard.Brand,
                Amount = transactionRequest.Amount,
                NeedAntiFraud = store.AntiFraud,
                LastDigits = transactionRequest.CreditCard.CardNumber.Substring(transactionRequest.CreditCard.CardNumber.Length - 4),
                Holder = transactionRequest.CreditCard.Holder
            }).Entity;

            if (store.AntiFraud)
            {
                transaction.SuccessAntiFraud = true;
                return transaction;
            }

            var gatewayInstance = GatewayIterator.GetGateway(gateway);
            var transactionResult = gatewayInstance.MakeTransaction(transactionRequest);
            transaction.Success = true;
            ctx.SaveChanges();
            return transaction;
        }
    }
}
