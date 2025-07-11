using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodifyCore.Data.Configuration;
using System.Data;

namespace MoodifyCore.Data;

public class MoodifyDataContext : DbContext
{
    public MoodifyDataContext()
    {
    }

    public MoodifyDataContext(DbContextOptions<MoodifyDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Activity> Activities { get; set; }
    public virtual DbSet<Playlist> Playlists { get; set; }
    public virtual DbSet<ActivityPlaylist> ActivityPlaylists { get; set; }
    public virtual DbSet<SensorData> SensorDatas { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityConfiguration());
        modelBuilder.ApplyConfiguration(new PlaylistConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityPlaylistConfiguration());
        modelBuilder.ApplyConfiguration(new SensorDataConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityLogConfiguration());

        SetDateTimeUtc(modelBuilder);

    }
    private static void SetDateTimeUtc(ModelBuilder builder)
    {
        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    property.SetValueConverter(dateTimeConverter);
            }
        }
    }
} 