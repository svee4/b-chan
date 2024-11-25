using BChan.Bot.Database;
using BChan.Bot.Infra.DiscordEvents;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class MessageDeletedEventHandler
{
	private static async ValueTask HandleAsync(
		MessageDeletedEvent @event,
		AppDbContext dbContext,
		CancellationToken token)
	{
		var messageId = @event.Message.Id;

		// when starboard message is manually deleted, we also delete it from database so we dont get ghosts
		// we do NOT delete starboard messages when the original message gets deleted
		_ = await dbContext.StarredMessages
			.Where(starredMessage => starredMessage.StarboardMessageId == messageId)
			.ExecuteDeleteAsync(token);
	}
}
