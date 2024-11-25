using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BChan.Bot.Migrations
{
    /// <inheritdoc />
    public partial class AddStarboardChannelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "StarboardChannelId",
                table: "StarredMessages",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarboardChannelId",
                table: "StarredMessages");
        }
    }
}
