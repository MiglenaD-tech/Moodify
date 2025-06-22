using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> entity)
    {
        entity.ToTable("playlist");

        entity.HasKey(e => e.Id).HasName("pk_playlist");

        entity.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id")
            .HasColumnType("integer");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name");

        entity.Property(e => e.ExternalId)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("external_id");

        entity.Property(e => e.Platform)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("platform");

        entity.Property(e => e.UserId)
            .HasColumnName("user_id")
            .HasColumnType("integer");

        entity.Property(e => e.ImageUrl)
              .HasMaxLength(512)
              .HasColumnName("image_url");
        }
    }
}
