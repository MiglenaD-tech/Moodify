using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoodifyCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emoji",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "activity");

            migrationBuilder.AddColumn<string>(
                name: "time_zone",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "playlist",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.InsertData(
                table: "activity",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Walking" },
                    { 2, "Running" },
                    { 3, "On Foot" },
                    { 4, "On Bicycle" },
                    { 5, "In Vehicle" },
                    { 6, "Still" },
                    { 7, "Tilting" },
                    { 8, "Unknown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "activity",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "time_zone",
                table: "user");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "playlist");

            migrationBuilder.AddColumn<string>(
                name: "emoji",
                table: "activity",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "activity",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
