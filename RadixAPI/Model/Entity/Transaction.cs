using RadixAPI.Providers;
using System;

namespace RadixAPI.Model.Entity
{
    public class Transaction : DbEntity<Guid>
    {
        public Store Store { get; set; }
        public DateTime Date { get; set; }
        public string Brand { get; set; }
        public ProviderEnum Provider { get; set; }
        public int Amount { get; set; }
        public bool NeedAntiFraud { get; set; }
        public bool SuccessAntiFraud { get; set; }
        public string LastDigits { get; set; }
        public string Holder { get; set; }
        public bool Success { get; set; }
    }
}