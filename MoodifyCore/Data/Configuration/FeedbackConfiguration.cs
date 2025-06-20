using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.ToTable("feedback");

            entity.HasKey(e => e.Id).HasName("pk_feedback");

            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd()
                  .HasColumnType("integer");

            entity.Property(e => e.FeedbackTime)
                  .HasColumnName("feedback_time")
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .IsRequired();

            entity.Property(e => e.UserId)
                  .HasColumnName("user_id")
                  .HasColumnType("integer")
                  .IsRequired();

            entity.Property(e => e.IsCorrect)
                  .HasColumnName("is_correct")
                  .HasColumnType("boolean")
                  .HasDefaultValue(false);

        }
    }
}
