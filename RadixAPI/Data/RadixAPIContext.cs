using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RadixAPI.Model;

namespace RadixAPI.Data
{

  public class RadixAPIContext : DbContext
  {
    public DbSet<Store> Stores { get; set; }
    public RadixAPIContext(DbContextOptions<RadixAPIContext> options) : base(options)
    {

    }
  }
}