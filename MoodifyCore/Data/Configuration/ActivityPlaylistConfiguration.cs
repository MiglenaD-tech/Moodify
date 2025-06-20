using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class ActivityPlaylistConfiguration : IEntityTypeConfiguration<ActivityPlaylist>
    {
        public void Configure(EntityTypeBuilder<ActivityPlaylist> entity)
        {
            entity.ToTable("activity_playlist");

            entity.HasKey(e => e.Id).HasName("pk_activity_playlist");

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasColumnType("integer")
                  .HasColumnName("id");

            entity.Property(e => e.ActivityId)
                  .HasColumnName("activity_id")
                  .HasColumnType("integer")
                  .IsRequired();

            entity.Property(e => e.PlaylistId)
                  .HasColumnName("playlist_id")
                  .HasColumnType("integer")
                  .IsRequired();

            entity.Property(e => e.UserId)
                  .HasColumnName("user_id")
                  .HasColumnType("integer");

            entity.Property(e => e.LinkedAt)
                  .HasColumnName("linked_at")
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }
}
