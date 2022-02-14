﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> entity)
        {
            entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Tbl_RolePermission_RP_PermissionID");

            entity.HasIndex(e => e.RoleId)
                .HasName("IX_Tbl_RolePermission_RP_RoleID");

            entity.Property(e => e.RolePermissionId).HasColumnName("RolePermissionID");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.Property(e => e.RolePermissionGuid)
                .HasColumnName("RolePermissionGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Permission)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Permission");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");
        }
    }
}
