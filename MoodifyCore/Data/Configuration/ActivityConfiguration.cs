using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoodifyCore.Data.Configuration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> entity)
        {
            entity.ToTable("activity");

            entity.HasKey(e => e.Id).HasName("pk_activity");

            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .HasColumnType("integer");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(100)")
                  .IsRequired();

            entity.Property(e => e.Emoji)
                  .HasColumnName("emoji")
                  .HasColumnType("varchar(10)");

        }
    }
}
