using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BChan.Bot.Migrations
{
    /// <inheritdoc />
    public partial class net9migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinStarboardReactions",
                table: "BotConfiguration",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "MinStarboardReactions",
                table: "BotConfiguration",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
