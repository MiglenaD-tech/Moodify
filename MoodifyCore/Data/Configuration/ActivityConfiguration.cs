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
                  .ValueGeneratedOnAdd()
                  .HasColumnName("id")
                  .HasColumnType("integer");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(100)")
                  .IsRequired();

            entity.HasData(
                new Activity { Id = 1, Name = "Walking" },
                new Activity { Id = 2, Name = "Running" },
                new Activity { Id = 3, Name = "On Foot" },
                new Activity { Id = 4, Name = "On Bicycle" },
                new Activity { Id = 5, Name = "In Vehicle" },
                new Activity { Id = 6, Name = "Still" },
                new Activity { Id = 7, Name = "Tilting" },
                new Activity { Id = 8, Name = "Unknown" }
            );
        }
    }
}
