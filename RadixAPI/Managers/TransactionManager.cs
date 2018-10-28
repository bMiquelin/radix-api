using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Providers;
using RadixAPI.Model.Entity;
using System;
using System.Linq;
using RadixAPI.AntiFraud;
using RadixAPI.Exceptions;

namespace RadixAPI.Managers
{
    public class TransactionManager
    {
        private readonly RadixAPIContext ctx;
        private readonly ProviderIterator providerIterator;
        private readonly IAntiFraudProvider antiFraudProvider;
        public TransactionManager(RadixAPIContext ctx, ProviderIterator providerIterator, IAntiFraudProvider antiFraudProvider)
        {
            this.ctx = ctx;
            this.providerIterator = providerIterator;
            this.antiFraudProvider = antiFraudProvider;
        }

        private ProviderEnum GetProviderByRules(Store store, string brand)
        {
            var providerRules = store.StoreProviderRules.OrderBy(rule => rule.Priority);
            return ProviderRuleManager.PickProvider(brand, providerRules);
        }

        private bool CheckAntifraud(ref Transaction transaction, TransactionRequest transactionRequest)
        {
            if (!transaction.Store.AntiFraud) return true;
            try
            {
                transaction.SuccessAntiFraud = antiFraudProvider.Validate(transactionRequest);
            }
            catch (AntiFraudException ex)
            {
                transaction.ErrorMessage = ex.Message;
                transaction.SuccessAntiFraud = false;
            }

            return transaction.SuccessAntiFraud;
        }

        private bool MakeProviderTransaction(ref Transaction transaction, TransactionRequest transactionRequest)
        {
            var providerInstance = providerIterator.CreateProviderInstance(transaction.Provider);

            try
            {
                transaction.Success = providerInstance.MakeTransaction(transaction.Id, transactionRequest);
            }
            catch (ProviderException ex)
            {
                transaction.ErrorMessage = ex.Message;
                transaction.Success = false;
            }

            return transaction.Success;
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
            transactionRequest.TransactionId = transaction.Id;

            if (!CheckAntifraud(ref transaction, transactionRequest)) return transaction;

            if (!MakeProviderTransaction(ref transaction, transactionRequest)) return transaction;

            ctx.SaveChanges();
            return transaction;
        }
    }
}
