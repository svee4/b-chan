using BChan.Bot.Infra;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace BChan.Bot.Features.Starboard;

[Group("starboard", "Starboard Configuration")]
public sealed class ConfigurationModule(BotConfigurationManager manager) : InteractionModuleBase
{
	private readonly BotConfigurationManager _manager = manager;

	[SlashCommand("channel", "Configure the channel in which Starboard messages will be posted")]
	[RequireUserPermission(GuildPermission.Administrator)]
	public async Task Channel(SocketChannel channel)
	{
		await _manager.SetStarboardChannelId(channel.Id, default);
		await RespondAsync("Updated the Starboard's channel!", ephemeral: true);
	}

	[SlashCommand("reactions", "Set the minimum amount of reactions required to trigger the starboard")]
	[RequireUserPermission(GuildPermission.Administrator)]
	public async Task MinReactions(byte count)
	{
		await _manager.SetMinStarboardReactions(count, default);
		await RespondAsync("Updated the Starboard's minimum reaction count!", ephemeral: true);
	}
}
