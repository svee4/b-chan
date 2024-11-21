using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord;
using Discord.WebSocket;
using Immediate.Handlers.Shared;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class ReactionAddedEventHandler
{
	private static readonly Emoji _starEmoji = Emoji.Parse(":star:");

	private static async ValueTask HandleAsync(
		ReactionAddedEvent @event,
		BotConfigurationManager config,
		DiscordSocketClient client,
		CancellationToken ct)
	{
		var message = await @event.Message.GetOrDownloadAsync();

		var minStarCount = await config.GetMinStarboardReactions(ct);

		var actualStarCount = message.Reactions[_starEmoji].ReactionCount;

		if (minStarCount != actualStarCount) return;

		var starboardChannelId = await config.GetStarboardChannelId(ct);
		if (starboardChannelId == null) return;

		var starboardChannel = client.Guilds.Single()
			.TextChannels.First(channel => channel.Id == starboardChannelId.Value);
		if (starboardChannel == null) return;

		await starboardChannel.SendMessageAsync("Starboard Message Added");

		await message.Channel.SendMessageAsync("Hallo!");
	}
}
