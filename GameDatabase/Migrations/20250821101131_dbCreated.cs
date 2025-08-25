using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameDatabase.Migrations
{
    /// <inheritdoc />
    public partial class dbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    KD = table.Column<float>(type: "real", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Accuracy", "Email", "Headshots", "KD", "Kills", "Rank", "Username" },
                values: new object[,]
                {
                    { 1, 53, "abc@gmail.com", 9, 0.6f, 78, 2, "abc" },
                    { 2, 75, "something@gmail.com", 21, 0.79f, 190, 3, "xingq" },
                    { 3, 80, "matt@gmail.com", 89, 0.95f, 294, 4, "matt41" },
                    { 4, 81, "user3@gmail.com", 90, 0.98f, 456, 6, "user39" },
                    { 5, 66, "bot@gmail.com", 2, 0.5f, 34, 1, "bot" },
                    { 6, 76, "bee33@gmail.com", 6, 0.85f, 60, 2, "bee3" },
                    { 7, 67, "newuser@gmail.com", 3, 0.7f, 56, 1, "player213" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
