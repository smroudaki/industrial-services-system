﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.HasIndex(e => e.DocumentId);

            entity.HasIndex(e => e.SliderCodeId);

            entity.HasIndex(e => e.UserId);

            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.Property(e => e.Abstract).IsRequired();

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description).IsRequired();

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

            entity.Property(e => e.IsSuggested).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PostGuid)
                .HasColumnName("PostGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Title).IsRequired();

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Document)
                .WithMany(p => p.Post)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Document");

            entity.HasOne(d => d.SliderCode)
                .WithMany(p => p.Post)
                .HasForeignKey(d => d.SliderCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Code");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Post)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        }
    }
}
