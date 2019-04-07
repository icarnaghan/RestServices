using System.Threading;
using Microsoft.EntityFrameworkCore;
using RestServices.Data.Configurations;
using RestServices.Domain.Entities;

namespace RestServices.Data
{
    public class RestServicesContext : DbContext
    {
        public virtual DbSet<Country> Country { get; set; }

        public static long InstanceCount;

        public RestServicesContext(DbContextOptions options) : base(options) 
            => Interlocked.Increment(ref InstanceCount);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CountryConfiguration(modelBuilder.Entity<Country>());
        }
    }
}