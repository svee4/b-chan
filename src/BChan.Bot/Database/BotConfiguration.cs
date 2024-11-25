using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Bot.Database;

public sealed class BotConfiguration : IEntityTypeConfiguration<BotConfiguration>
{
	public int Id { get; private set; } // always 1... right ?

	public IList<ulong> AutoRolesIds { get; private set; } = null!;

	public int MinStarboardReactions { get; set; }

	public ulong? StarboardChannelId { get; set; }

	public static BotConfiguration CreateDefault() => new()
	{
		AutoRolesIds = [],
		MinStarboardReactions = 3,
		StarboardChannelId = null,
	};

	public void Configure(EntityTypeBuilder<BotConfiguration> builder) { }
}
