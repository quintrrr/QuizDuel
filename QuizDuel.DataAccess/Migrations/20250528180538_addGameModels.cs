using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDuel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addGameModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "picture",
                table: "users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    player1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    player2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    currentRound = table.Column<int>(type: "integer", nullable: false),
                    turn = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    gameId = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    categoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rounds", x => x.id);
                    table.ForeignKey(
                        name: "FK_rounds_games_gameId",
                        column: x => x.gameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playerAnswers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    roundId = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false),
                    questionId = table.Column<Guid>(type: "uuid", nullable: false),
                    selected = table.Column<int>(type: "integer", nullable: false),
                    isCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_playerAnswers_rounds_roundId",
                        column: x => x.roundId,
                        principalTable: "rounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roundQuestions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    roundId = table.Column<Guid>(type: "uuid", nullable: false),
                    questionIndex = table.Column<int>(type: "integer", nullable: false),
                    questionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roundQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_roundQuestions_rounds_roundId",
                        column: x => x.roundId,
                        principalTable: "rounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_playerAnswers_roundId",
                table: "playerAnswers",
                column: "roundId");

            migrationBuilder.CreateIndex(
                name: "IX_roundQuestions_roundId",
                table: "roundQuestions",
                column: "roundId");

            migrationBuilder.CreateIndex(
                name: "IX_rounds_gameId",
                table: "rounds",
                column: "gameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playerAnswers");

            migrationBuilder.DropTable(
                name: "roundQuestions");

            migrationBuilder.DropTable(
                name: "rounds");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.AlterColumn<string>(
                name: "picture",
                table: "users",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
