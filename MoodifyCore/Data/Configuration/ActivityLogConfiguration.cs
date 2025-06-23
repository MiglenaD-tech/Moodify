using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("activity_log")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnType("int(11)").HasColumnName("user_id");
            entity.Property(e => e.ActivityId).HasColumnType("int(11)").HasColumnName("activity_id");
            entity.Property(e => e.PlaylistId).HasColumnType("int(11)").HasColumnName("playlist_id");
            entity.Property(e => e.Timestamp).HasColumnType("datetime").HasColumnName("timestamp").HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.TriggeredBy).HasMaxLength(200).HasColumnName("triggered_by");
            entity.Property(e => e.Note).HasMaxLength(500).HasColumnName("note");
        }
    }
}
