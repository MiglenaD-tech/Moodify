using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> entity)
        {
            entity.HasKey(e => e.Id).HasName("pk_activity_log");

            entity.ToTable("activity_log");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.UserId)
                .HasColumnName("user_id");

            entity.Property(e => e.ActivityId)
                .HasColumnName("activity_id");

            entity.Property(e => e.PlaylistId)
                .HasColumnName("playlist_id");

            entity.Property(e => e.Timestamp)
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .HasColumnName("timestamp");

            entity.Property(e => e.TriggeredBy)
                  .HasMaxLength(200)
                  .HasColumnName("triggered_by");

            entity.Property(e => e.Note)
                  .HasMaxLength(500)
                  .HasColumnName("note");
        }
    }
}
