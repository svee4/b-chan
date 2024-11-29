using BChan.Bot.Database;
using BChan.Bot.Infra.DiscordEvents;
using Microsoft.EntityFrameworkCore;

namespace BChan.Bot.Features.Starboard;

public sealed class MessageDeletedEventHandler(AppDbContext dbContext) : IEventHandler<MessageDeletedEvent>
{
	public async Task Handle(MessageDeletedEvent @event, CancellationToken token)
	{
		// when starboard message is manually deleted, we also delete it from database so we dont get ghosts
		// we do NOT delete starboard messages when the original message gets deleted
		var messageId = @event.Message.Id;

		_ = await dbContext.StarredMessages
			.Where(starredMessage => starredMessage.StarboardMessageId == messageId)
			.ExecuteDeleteAsync(token);
	}
}
