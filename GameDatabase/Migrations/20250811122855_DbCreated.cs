using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameDatabase.Migrations
{
    /// <inheritdoc />
    public partial class DbCreated : Migration
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
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false),
                    kills = table.Column<int>(type: "int", nullable: false),
                    KD = table.Column<float>(type: "real", nullable: false),
                    headshots = table.Column<int>(type: "int", nullable: false),
                    accuracy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "KD", "accuracy", "email", "headshots", "kills", "password", "rank", "username" },
                values: new object[,]
                {
                    { 1, 0.6f, 53, "abc@gmail.com", 9, 78, "abc123", 2, "abc" },
                    { 2, 0.79f, 75, "something@gmail.com", 21, 190, "iqjifnqw3", 3, "xingq" },
                    { 3, 0.95f, 80, "ice23@gmail.com", 89, 294, "jr3i214", 4, "matt41" }
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
