using RestServices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RestServices.Data.Configurations
{
    public class CountryConfiguration
    {
        public CountryConfiguration(EntityTypeBuilder<Country> entity)
        {
            entity.Property(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Alpha2).HasMaxLength(50);
            entity.Property(e => e.Alpha3).HasMaxLength(50);
            entity.Property(e => e.Iso).HasMaxLength(50);
        }
    }
}