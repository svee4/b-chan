using BChan.Worker.Infra;
using Discord.Interactions;
using Discord.WebSocket;

namespace BChan.Worker.Features.AutoRole;

[Group("autorole", "Autorole configuration")]
public sealed class ConfigurationModule(BotConfigurationManager manager, DiscordSocketClient client) : InteractionModuleBase
{
	private readonly BotConfigurationManager _manager = manager;
	private readonly DiscordSocketClient _client = client;

	[SlashCommand("add", "Add autorole")]
	[RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task Add(SocketRole role)
	{
		await _manager.AddAutoRole(role.Id, default);
		await RespondAsync($"Role {role.Name} added to autorole");
	}

	[SlashCommand("remove", "Remove autorole")]
	[RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task Remove(SocketRole role)
	{
		await _manager.RemoveAutoRole(role.Id, default);
		await RespondAsync($"Role {role.Name} removed from autorole");
	}

	[SlashCommand("list", "List autoroles")]
	[RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task List()
	{
		var roles = await _manager.GetAutoRoles(default);
		var roleNames = _client.Guilds.Single().Roles
							.Where(role => roles.Contains(role.Id))
							.Select(role => role.Name);
		await RespondAsync($"Autoroles: {string.Join(", ", roleNames)}");
	}
}
