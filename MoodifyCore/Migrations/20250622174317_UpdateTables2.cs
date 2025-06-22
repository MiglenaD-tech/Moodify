using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodifyCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "spotify_token_expires_at",
                table: "user",
                type: "timestamp",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "spotify_token_expires_at",
                table: "user");
        }
    }
}
