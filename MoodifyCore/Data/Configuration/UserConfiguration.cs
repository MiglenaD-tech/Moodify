using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomelo.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("email");

            entity.HasIndex(e => e.Email)
                .IsUnique()
                .HasDatabaseName("ix_user_email");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("created_at");

            entity.Property(e => e.GoogleId)
                .HasMaxLength(512)
                .HasColumnName("google_id");

            entity.Property(e => e.DeviceId)
                .HasMaxLength(200)
                .HasColumnName("device_id");

            entity.Property(e => e.SpotifyAccessToken)
                .HasMaxLength(512)
                .HasColumnName("spotify_access_token");

            entity.Property(e => e.SpotifyRefreshToken)
                .HasMaxLength(512)
                .HasColumnName("spotify_refresh_token");

            entity.Property(e => e.SpotifyTokenExpiresAt)
                .HasColumnType("datetime")
                .HasColumnName("spotify_token_expires_at");

            entity.Property(e => e.TimeZone)
                .HasMaxLength(255)
                .HasColumnName("time_zone");

            entity.HasIndex(e => e.Email)
              .IsUnique()
              .HasDatabaseName("ix_user_email");
        }
    }
}
