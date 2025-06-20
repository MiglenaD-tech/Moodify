﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoodifyCore.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("pk_user");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("integer");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("email");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.GoogleId)
                .HasMaxLength(512)
                .HasColumnName("google_id");

            entity.Property(e => e.DeviceId)
                .HasMaxLength(512)
                .HasColumnName("device_id");

            entity.Property(e => e.SpotifyAccessToken)
                .HasMaxLength(512)
                .HasColumnName("spotify_access_token");

            entity.Property(e => e.SpotifyRefreshToken)
                .HasMaxLength(512)
                .HasColumnName("spotify_refresh_token");

            entity.HasIndex(e => e.Email)
              .IsUnique()
              .HasDatabaseName("ix_user_email");
        }
    }
}
