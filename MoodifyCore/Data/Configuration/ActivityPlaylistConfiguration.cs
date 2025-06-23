using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class ActivityPlaylistConfiguration : IEntityTypeConfiguration<ActivityPlaylist>
    {
        public void Configure(EntityTypeBuilder<ActivityPlaylist> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("activity_playlist")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.PlaylistId).HasColumnType("int(11)").HasColumnName("playlist_id");
            entity.Property(e => e.ActivityId).HasColumnType("int(11)").HasColumnName("activity_id");
            entity.Property(e => e.UserId).HasColumnType("int(11)").HasColumnName("user_id");
            entity.Property(e => e.LinkedAt).HasColumnType("datetime").HasColumnName("linked_at").HasDefaultValueSql("current_timestamp()");

        }
    }
}
