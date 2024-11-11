using Microsoft.EntityFrameworkCore;

namespace BChan.Worker.Database;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{

	[Obsolete("Dont access this :( use GetBotConfiguration instead")]
	public DbSet<BotConfiguration> BotConfiguration { get; private set; } = null!;

#pragma warning disable CS0618 // Type or member is obsolete
	public async Task<BotConfiguration> GetBotConfiguration() => await BotConfiguration.FirstAsync();
#pragma warning restore CS0618 // Type or member is obsolete
}
