using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadixAPI.Model.Entity;

namespace RadixAPI.Data
{
    public class RadixAPIContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProviderRule> StoreProviderRules { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public RadixAPIContext(DbContextOptions<RadixAPIContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
    }
}