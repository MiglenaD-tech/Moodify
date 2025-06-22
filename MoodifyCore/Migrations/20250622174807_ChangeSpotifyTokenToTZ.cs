using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodifyCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSpotifyTokenToTZ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "spotify_token_expires_at",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "spotify_token_expires_at",
                table: "user",
                type: "timestamp without time zone",
                nullable: true, // или false
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true // или false
            );
        }
    }
}
