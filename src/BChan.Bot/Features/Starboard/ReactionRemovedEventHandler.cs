using BChan.Bot.Database;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord.WebSocket;
using Immediate.Handlers.Shared;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class ReactionRemovedEventHandler
{
	private static async ValueTask HandleAsync(
		ReactionRemovedEvent @event,
		DiscordSocketClient client,
		AppDbContext dbContext,
		CancellationToken ct)
	{
		if (!StarboardUtil.StarEmoji.Equals(@event.Reaction.Emote)) return;

		var message = await @event.Message.GetOrDownloadAsync();

		int newStarCount;
		if (message.Reactions.TryGetValue(StarboardUtil.StarEmoji, out var metadata))
		{
			newStarCount = metadata.ReactionCount;
		}
		else
		{
			// if no metadata then no reactions which means 0 reactions
			newStarCount = 0;
		}

		if (await StarboardUtil.GetStarredMessageByMessageId(dbContext, message.Id, ct) is { } starredMessage)
		{
			await StarboardUtil.UpdateStarredMessageStarCount(client, starredMessage, newStarCount, ct);
		}
	}
}
