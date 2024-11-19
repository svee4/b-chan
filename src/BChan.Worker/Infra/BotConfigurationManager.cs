using BChan.Worker.Database;
using Microsoft.EntityFrameworkCore;

namespace BChan.Worker.Infra;

// i dont know if making this huge manager class is a good idea but we will find out later

public sealed class BotConfigurationManager(AppDbContext dbContext)
{
	private readonly AppDbContext _dbContext = dbContext;

#pragma warning disable CS0618 // Type or member is obsolete (AppDbContext.BotConfiguration)
	private async Task<BotConfiguration> GetBotConfiguration(CancellationToken token) =>
		await _dbContext.BotConfiguration.SingleAsync(token);
#pragma warning restore CS0618 // Type or member is obsolete (AppDbContext.BotConfiguration)

	private async Task EditAndSave(Action<BotConfiguration> action, CancellationToken token)
	{
		var config = await GetBotConfiguration(token);
		action(config);
		await _dbContext.SaveChangesAsync(token);
	}

	public async Task<IList<ulong>> GetAutoRoles(CancellationToken token) =>
		(await GetBotConfiguration(token)).AutoRolesIds;

	public async Task AddAutoRole(ulong id, CancellationToken token) =>
		await EditAndSave(config => config.AutoRolesIds.Add(id), token);

	public async Task RemoveAutoRole(ulong id, CancellationToken token) =>
		await EditAndSave(config => config.AutoRolesIds.Remove(id), token);
}

