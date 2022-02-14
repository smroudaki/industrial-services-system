using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class PaymentProviderSettingConfiguration : IEntityTypeConfiguration<PaymentProviderSetting>
    {
        public void Configure(EntityTypeBuilder<PaymentProviderSetting> entity)
        {
            entity.HasIndex(e => e.PaymentProviderId);

            entity.Property(e => e.PaymentProviderSettingId).HasColumnName("PaymentProviderSettingID");

            entity.Property(e => e.Apikey)
                .IsRequired()
                .HasColumnName("APIKey")
                .HasMaxLength(128);

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Password).HasMaxLength(128);

            entity.Property(e => e.PaymentProviderId).HasColumnName("PaymentProviderID");

            entity.Property(e => e.PaymentProviderSettingGuid)
                .HasColumnName("PaymentProviderSettingGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Username).HasMaxLength(128);

            entity.HasOne(d => d.PaymentProvider)
                .WithMany(p => p.PaymentProviderSetting)
                .HasForeignKey(d => d.PaymentProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentProviderSetting_PaymentProvider");
        }
    }
}
