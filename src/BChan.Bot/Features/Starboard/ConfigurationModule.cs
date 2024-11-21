using BChan.Bot.Infra;
using Discord.Interactions;
using Discord.WebSocket;

namespace BChan.Bot.Features.Starboard;

[Group("starboard", "Starboard Configuration")]
public sealed class ConfigurationModule(BotConfigurationManager manager)
	: InteractionModuleBase
{
	[SlashCommand("channel", "Configure the channel in which Starboard messages will be posted")]
	[Discord.Commands.RequireUserPermission(Discord.GuildPermission.Administrator)]
	public async Task Channel(SocketChannel channel)
		=> await manager.SetStarboardChannelId(channel.Id, default);
}
