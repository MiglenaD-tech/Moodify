using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.FeedbackTime).HasColumnType("datetime").HasColumnName("feedback_time").HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.UserId).HasColumnType("int(11)").HasColumnName("user_id");
            entity.Property(e => e.PlaylistId).HasColumnType("int(11)").HasColumnName("playlist_id");
            entity.Property(e => e.ActivityId).HasColumnType("int(11)").HasColumnName("activity_id");
            entity.Property(e => e.IsCorrect).HasColumnType("bit").HasColumnName("is_correct");
        }
    }
}
