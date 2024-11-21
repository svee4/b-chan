using BChan.Bot.Database;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord;
using Discord.WebSocket;
using Immediate.Handlers.Shared;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class ReactionRemovedEventHandler
{
	private static async ValueTask HandleAsync(
		ReactionRemovedEvent @event,
		BotConfigurationManager config,
		DiscordSocketClient client,
		AppDbContext dbContext,
		CancellationToken ct)
	{
		if (!@event.Reaction.Emote.Equals(StarboardUtil.StarEmoji)) return;

		var message = await @event.Message.GetOrDownloadAsync();

		ReactionMetadata? metadata = message.Reactions.GetValueOrDefault(StarboardUtil.StarEmoji);

#pragma warning disable CA1508
		var newStarCount = metadata?.ReactionCount ?? 0;
#pragma warning restore CA1508

		await StarboardUtil.UpdateMessageStarCount(dbContext, client, config, message.Id, newStarCount, ct);
	}
}
