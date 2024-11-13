using Microsoft.EntityFrameworkCore;

namespace BChan.Worker.Database;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
	[Obsolete($"Do not access directly, use {nameof(Infra.BotConfigurationManager)}")]
	public DbSet<BotConfiguration> BotConfiguration { get; private set; } = null!;
}
