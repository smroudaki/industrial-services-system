using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class ContractorIntroductionCodeConfiguration : IEntityTypeConfiguration<ContractorIntroductionCode>
    {
        public void Configure(EntityTypeBuilder<ContractorIntroductionCode> entity)
        {
            entity.HasIndex(e => e.ContractorId);

            entity.HasIndex(e => e.NewContractorId);

            entity.Property(e => e.ContractorIntroductionCodeGuid)
                .HasColumnName("ContractorIntroductionCodeGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.ContractorIntroductionCodeId).HasColumnName("ContractorIntroductionCodeID");

            entity.Property(e => e.ContractorId).HasColumnName("ContractorID");

            entity.Property(e => e.NewContractorId).HasColumnName("NewContractorID");

            entity.HasOne(d => d.NewContractor)
                .WithMany(p => p.NewContractorIntroductionCode)
                .HasForeignKey(d => d.NewContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractorIntroductionCode_NewContractor");

            entity.HasOne(d => d.Contractor)
                .WithMany(p => p.ContractorIntroductionCode)
                .HasForeignKey(d => d.ContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractorIntroductionCode_Contractor");
        }
    }
}
