using BChan.Bot.Infra;
using Microsoft.EntityFrameworkCore;

namespace BChan.Bot.Database;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
	[Obsolete($"Do not access directly, use {nameof(BotConfigurationManager)}")]
	public DbSet<BotConfiguration> BotConfiguration { get; private set; } = null!;

	public DbSet<StarredMessage> StarredMessages { get; private set; } = null!;
}
