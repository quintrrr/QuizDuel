using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDuel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    passwordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    salt = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    picture = table.Column<string>(type: "varchar(255)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
