using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> entity)
        {
            entity.HasIndex(e => e.ContactUsBusinessTypeCodeId);

            entity.HasIndex(e => e.StateCodeId);

            entity.Property(e => e.ContactUsId).HasColumnName("ContactUsID");

            entity.Property(e => e.ContactUsBusinessTypeCodeId).HasColumnName("ContactUsBusinessTypeCodeID");

            entity.Property(e => e.ContactUsGuid)
                .HasColumnName("ContactUsGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.Message).IsRequired();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.StateCodeId).HasColumnName("StateCodeID");

            entity.HasOne(d => d.ContactUsBusinessTypeCode)
                .WithMany(p => p.ContactUsBusinessType)
                .HasForeignKey(d => d.ContactUsBusinessTypeCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactUs_ContactUsBusinessTypeCode");

            entity.HasOne(d => d.StateCode)
                .WithMany(p => p.ContactUsState)
                .HasForeignKey(d => d.StateCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactUs_StateCode");
        }
    }
}
