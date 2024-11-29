using BChan.Bot.Database;
using BChan.Bot.Infra.DiscordEvents;
using Discord.WebSocket;

namespace BChan.Bot.Features.Starboard;

public sealed class ReactionRemovedEventHandler(
	DiscordSocketClient client,
	AppDbContext dbContext) : IEventHandler<ReactionRemovedEvent>
{
	public async Task Handle(ReactionRemovedEvent @event, CancellationToken token)
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

		if (await StarboardUtil.GetStarredMessageByMessageId(dbContext, message.Id, token) is { } starredMessage)
		{
			await StarboardUtil.UpdateStarredMessageStarCount(client, starredMessage, newStarCount, token);
		}
	}
}
