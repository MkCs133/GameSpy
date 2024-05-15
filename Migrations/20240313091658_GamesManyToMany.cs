using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSpy.Migrations
{
    /// <inheritdoc />
    public partial class GamesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_GAMES_USER_GAME_USER",
                table: "GAMES");

            migrationBuilder.DropIndex(
                name: "USER_GAMES_FK",
                table: "GAMES");

            migrationBuilder.DropColumn(
                name: "USERID",
                table: "GAMES");

            migrationBuilder.RenameColumn(
                name: "RATING",
                table: "GAMES",
                newName: "Rating");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "GAMES",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2,1)");

            migrationBuilder.CreateTable(
                name: "USERS_GAMES",
                columns: table => new
                {
                    GAMESID = table.Column<int>(type: "int", nullable: false),
                    USERID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_GAMES", x => new { x.GAMESID, x.USERID });
                    table.ForeignKey(
                        name: "FK_USER_GAM_USER_GAME_USER",
                        column: x => x.USERID,
                        principalTable: "USER",
                        principalColumn: "USERID");
                    table.ForeignKey(
                        name: "FK_USER_GAM_USER_GAM_GAME",
                        column: x => x.GAMESID,
                        principalTable: "GAMES",
                        principalColumn: "GAMEID");
                });

            migrationBuilder.CreateIndex(
                name: "USER_GAMES_FK",
                table: "USERS_GAMES",
                column: "GAMESID");

            migrationBuilder.CreateIndex(
                name: "USER_GAMES2_FK",
                table: "USERS_GAMES",
                column: "USERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "USERS_GAMES");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "GAMES",
                newName: "RATING");

            migrationBuilder.AlterColumn<decimal>(
                name: "RATING",
                table: "GAMES",
                type: "numeric(2,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "USERID",
                table: "GAMES",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "PC_GAMES_FK",
                table: "GAMES",
                column: "PCID");

            migrationBuilder.AddForeignKey(
                name: "FK_GAMES_USER_GAME_USER",
                table: "GAMES",
                column: "USERID",
                principalTable: "USER",
                principalColumn: "USERID");
        }
    }
}
