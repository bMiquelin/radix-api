using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Providers;
using RadixAPI.Model.Entity;
using System;
using System.Linq;

namespace RadixAPI.Managers
{
    public class TransactionManager
    {
        private readonly RadixAPIContext ctx;
        public TransactionManager(RadixAPIContext ctx)
        {
            this.ctx = ctx;
        }

        private ProviderEnum GetProviderByRules(Store store, string brand)
        {
            var providerRules = store.StoreProviderRules.OrderBy(rule => rule.Priority);
            return ProviderRuleManager.PickProvider(brand, providerRules);
        }

        private bool CheckAntifraud(ref Transaction transaction)
        {
            if (!transaction.Store.AntiFraud) return true;



            transaction.SuccessAntiFraud = true;
            return true;
        }

        private bool MakeProviderTransaction(ref Transaction transaction, TransactionRequest transactionRequest)
        {
            var providerInstance = ProviderIterator.CreateProviderInstance(transaction.Provider);
            var transactionResult = providerInstance.MakeTransaction(transaction.Id, transactionRequest);
            transaction.Success = transactionResult;
            return true;
        }

        public Transaction CreateTransaction(Store store, TransactionRequest transactionRequest)
        {
            var transaction = ctx.Transactions.Add(new Transaction
            {
                Store = store,
                Date = DateTime.UtcNow,
                Provider = GetProviderByRules(store, transactionRequest.CreditCard.Brand),
                Brand = transactionRequest.CreditCard.Brand,
                Amount = transactionRequest.Amount,
                NeedAntiFraud = store.AntiFraud,
                LastDigits = transactionRequest.CreditCard.CardNumber.Substring(transactionRequest.CreditCard.CardNumber.Length - 4),
                Holder = transactionRequest.CreditCard.Holder
            }).Entity;

            if (!CheckAntifraud(ref transaction)) return transaction;

            if (!MakeProviderTransaction(ref transaction, transactionRequest)) return transaction;

            ctx.SaveChanges();
            return transaction;
        }
    }
}
