using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<IndustrialServicesSystem.Domain.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<IndustrialServicesSystem.Domain.Entities.Application> entity)
        {
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

            entity.Property(e => e.ApplicationGuid)
                .HasColumnName("ApplicationGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.LatestVersionCode).HasMaxLength(128);

            entity.Property(e => e.MinVersionCode).HasMaxLength(128);

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Name).IsRequired()
                .HasMaxLength(128);
        }
    }
}
