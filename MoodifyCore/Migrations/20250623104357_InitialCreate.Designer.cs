﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodifyCore.Data;

#nullable disable

namespace MoodifyCore.Migrations
{
    [DbContext(typeof(MoodifyDataContext))]
    [Migration("20250623104357_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MoodifyCore.Data.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("activity", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Walking"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Running"
                        },
                        new
                        {
                            Id = 3,
                            Name = "On Foot"
                        },
                        new
                        {
                            Id = 4,
                            Name = "On Bicycle"
                        },
                        new
                        {
                            Id = 5,
                            Name = "In Vehicle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Still"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tilting"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Unknown"
                        });
                });

            modelBuilder.Entity("MoodifyCore.Data.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int(11)")
                        .HasColumnName("activity_id");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("note");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int(11)")
                        .HasColumnName("playlist_id");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("timestamp")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("TriggeredBy")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("triggered_by");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("activity_log", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("MoodifyCore.Data.ActivityPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int(11)")
                        .HasColumnName("activity_id");

                    b.Property<DateTime>("LinkedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("linked_at")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int(11)")
                        .HasColumnName("playlist_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("activity_playlist", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("MoodifyCore.Data.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int(11)")
                        .HasColumnName("activity_id");

                    b.Property<DateTime>("FeedbackTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("feedback_time")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<ulong>("IsCorrect")
                        .HasColumnType("bit")
                        .HasColumnName("is_correct");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int(11)")
                        .HasColumnName("playlist_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("feedback", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("MoodifyCore.Data.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("external_id");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("platform");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("playlist", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("MoodifyCore.Data.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("ActivityType")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("activity_type");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("device_id");

                    b.Property<int?>("HeartRate")
                        .HasColumnType("int(11)")
                        .HasColumnName("heart_rate");

                    b.Property<float?>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("longitude");

                    b.Property<int?>("StepCount")
                        .HasColumnType("int(11)")
                        .HasColumnName("step_count");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime")
                        .HasColumnName("timestamp");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("sensor_data", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("MoodifyCore.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("device_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("GoogleId")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("google_id");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("SpotifyAccessToken")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("spotify_access_token");

                    b.Property<string>("SpotifyRefreshToken")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("spotify_refresh_token");

                    b.Property<DateTime?>("SpotifyTokenExpiresAt")
                        .HasColumnType("datetime")
                        .HasColumnName("spotify_token_expires_at");

                    b.Property<string>("TimeZone")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("time_zone");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.ToTable("user", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });
#pragma warning restore 612, 618
        }
    }
}
