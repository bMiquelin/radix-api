using System;

namespace RadixAPI.Model.Entity
{
    public class Transaction : DbEntity<Guid>
    {
        public Store Store { get; set; }
        public string Brand { get; set; }
    }
}