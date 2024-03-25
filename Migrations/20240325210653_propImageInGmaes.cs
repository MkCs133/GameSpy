using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSpy.Migrations
{
    /// <inheritdoc />
    public partial class propImageInGmaes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMAGE",
                table: "GAMES",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
