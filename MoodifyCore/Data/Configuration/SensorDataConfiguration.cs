using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> entity)
        {
            entity.ToTable("sensor_data");

            entity.HasKey(e => e.Id).HasName("pk_sensor_data");

            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd()
                  .HasColumnType("integer");

            entity.Property(e => e.UserId)
                  .HasColumnName("user_id")
                  .HasColumnType("integer")
                  .IsRequired();

            entity.Property(e => e.DeviceId)
                  .HasColumnName("device_id")
                  .HasColumnType("varchar(200)")
                  .IsRequired();

            entity.Property(e => e.Timestamp)
                  .HasColumnName("timestamp")
                  .HasColumnType("timestamp")
                  .IsRequired();

            entity.Property(e => e.HeartRate)
                  .HasColumnName("heart_rate")
                  .HasColumnType("integer");

            entity.Property(e => e.StepCount)
                  .HasColumnName("step_count")
                  .HasColumnType("integer");

            entity.Property(e => e.ActivityType)
                  .HasColumnName("activity_type")
                  .HasColumnType("varchar(100)");

            entity.Property(e => e.Latitude)
                  .HasColumnName("latitude")
                  .HasColumnType("double precision");

            entity.Property(e => e.Longitude)
                  .HasColumnName("longitude")
                  .HasColumnType("double precision");

        }
    }
}
