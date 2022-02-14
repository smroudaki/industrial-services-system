﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Infrastructure.Persistence.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> entity)
        {
            entity.HasIndex(e => e.OrderRequestId);

            entity.HasIndex(e => e.UserId);

            entity.Property(e => e.ChatMessageId).HasColumnName("ChatMessageID");

            entity.Property(e => e.ChatMessageGuid)
                .HasColumnName("ChatMessageGUID")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.OrderRequestId).HasColumnName("OrderRequestID");

            entity.Property(e => e.SentAt).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Text).IsRequired();

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Document)
                .WithMany(p => p.ChatMessage)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatMessage_Document");

            entity.HasOne(d => d.OrderRequest)
                .WithMany(p => p.ChatMessage)
                .HasForeignKey(d => d.OrderRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatMessage_OrderRequest");

            entity.HasOne(d => d.User)
                .WithMany(p => p.ChatMessage)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatMessage_User");
        }
    }
}
