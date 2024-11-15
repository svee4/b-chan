using BChan.Worker.Infra;
using Discord.Interactions;
using Discord.WebSocket;
using System.Diagnostics;

namespace BChan.Worker.Features.AutoRole;

[Group("configure", "Configure things ^_^")]
public sealed class ConfigurationModule(BotConfigurationManager manager) : InteractionModuleBase
{
	private readonly BotConfigurationManager _manager = manager;

	[SlashCommand("autorole", "Auto role.,,")]
	public async Task Thing(ConfigurationAction action, SocketRole role)
	{
		switch (action)
		{
			case ConfigurationAction.Add:
				await _manager.AddAutoRole(role.Id, default);
				await RespondAsync($"Role {role.Name} added to autorole");
				break;

			case ConfigurationAction.Remove:
				await _manager.RemoveAutoRole(role.Id, default);
				await RespondAsync($"Role {role.Name} removed from autorole");
				break;

			default: throw new UnreachableException();
		}
	}

	// i dont know why Directory.Build.props NoWarn isnt working on this???
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1008:Enums should have zero value", Justification = "<Pending>")]
	public enum ConfigurationAction
	{
		Add = 1,
		Remove
	}
}
