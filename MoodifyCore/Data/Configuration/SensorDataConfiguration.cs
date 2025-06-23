using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoodifyCore.Data.Configuration
{
    public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sensor_data")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnType("int(11)").HasColumnName("user_id");
            entity.Property(e => e.DeviceId).HasMaxLength(200).HasColumnName("device_id");
            entity.Property(e => e.Timestamp).HasColumnType("datetime").HasColumnName("timestamp");
            entity.Property(e => e.HeartRate).HasColumnType("int(11)").HasColumnName("heart_rate");
            entity.Property(e => e.StepCount).HasColumnType("int(11)").HasColumnName("step_count");
            entity.Property(e => e.ActivityType).HasMaxLength(200).HasColumnName("activity_type");
            entity.Property(e => e.Latitude).HasColumnType("float").HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnType("float").HasColumnName("longitude");

        }
    }
}
