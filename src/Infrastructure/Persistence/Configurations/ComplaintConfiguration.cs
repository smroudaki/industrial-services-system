using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> entity)
        {
            entity.HasIndex(e => e.StateCodeId);

            entity.HasIndex(e => e.UserId);

            entity.Property(e => e.ComplaintId).HasColumnName("ComplaintID");

            entity.Property(e => e.ComplaintGuid)
                .HasColumnName("ComplaintGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description).IsRequired();

            entity.Property(e => e.StateCodeId).HasColumnName("StateCodeID");

            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(512);

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Complaint)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Complaint_User");

            entity.HasOne(d => d.StateCode)
                .WithMany(p => p.Complaint)
                .HasForeignKey(d => d.StateCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Complaint_Code");
        }
    }
}
