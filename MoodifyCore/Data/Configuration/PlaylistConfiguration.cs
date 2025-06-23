using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("playlist")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            entity.Property(e => e.ExternalId).IsRequired().HasMaxLength(255).HasColumnName("external_id");
            entity.Property(e => e.Platform).IsRequired().HasMaxLength(100).HasColumnName("platform");
            entity.Property(e => e.ImageUrl).HasMaxLength(512).HasColumnName("image_url");
            entity.Property(e => e.UserId).HasColumnType("int(11)").HasColumnName("user_id");
        }
    }
}
