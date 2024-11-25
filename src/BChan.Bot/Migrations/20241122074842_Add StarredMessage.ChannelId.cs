using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BChan.Bot.Migrations
{
    /// <inheritdoc />
    public partial class AddStarredMessageChannelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ChannelId",
                table: "StarredMessages",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "StarredMessages");
        }
    }
}
