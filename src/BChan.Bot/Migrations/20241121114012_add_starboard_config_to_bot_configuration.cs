using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BChan.Bot.Migrations;

    /// <inheritdoc />
    public partial class add_starboard_config_to_bot_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MinStarboardReactions",
                table: "BotConfiguration",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "StarboardChannelId",
                table: "BotConfiguration",
                type: "numeric(20,0)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinStarboardReactions",
                table: "BotConfiguration");

            migrationBuilder.DropColumn(
                name: "StarboardChannelId",
                table: "BotConfiguration");
        }
    }
