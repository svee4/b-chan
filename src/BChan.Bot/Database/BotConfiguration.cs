using Discord;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Bot.Database;

public sealed class BotConfiguration : IEntityTypeConfiguration<BotConfiguration>
{
	public int Id { get; private set; } // always 1... right ?

	public IList<ulong> AutoRolesIds { get; private init; } = null!;

	public byte MinStarboardReactions { get; private init; } = 1;

	public ulong? StarboardChannelId { get; set; }
	
	public static BotConfiguration CreateDefault() => new BotConfiguration()
	{
		AutoRolesIds = [],
		MinStarboardReactions = 1,
		StarboardChannelId = null,
	};

	public void Configure(EntityTypeBuilder<BotConfiguration> builder) { }
}
