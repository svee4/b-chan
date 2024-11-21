using BChan.Bot.Infra;
using Discord.Interactions;
using Discord.WebSocket;

namespace BChan.Bot.Features.Starboard;

[Group("starboard", "Starboard Configuration")]
public sealed class ConfigurationModule(BotConfigurationManager manager)
	: InteractionModuleBase
{
	[SlashCommand("channel", "Configure the channel in which Starboard messages will be posted")]
	[RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task Channel(SocketChannel channel)
		=> await manager.SetStarboardChannelId(channel.Id, default);

	[SlashCommand("reactions", "Set the minimum amount of reactions required to trigger the starboard")]
	[RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task MinReactions(byte count)
		=> await manager.SetMinStarboardReactions(count, default);
}
