using BChan.Bot.Database;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord;
using Discord.WebSocket;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class ReactionAddedEventHandler
{
	private static async ValueTask HandleAsync(
		ReactionAddedEvent @event,
		BotConfigurationManager config,
		DiscordSocketClient client,
		AppDbContext dbContext,
		CancellationToken ct)
	{
		if (!StarboardUtil.StarEmoji.Equals(@event.Reaction.Emote)) return;

		if (await config.GetStarboardChannelId(ct) is not { } starboardChannelId) return;

		var message = await @event.Message.GetOrDownloadAsync();

		var starboardChannel = client.Guilds.Single().TextChannels.FirstOrDefault(channel => channel.Id == starboardChannelId);
		if (starboardChannel is null)
		{
			_ = await message.Channel.SendMessageAsync("Starboard channel is configured but is not a valid channel");
			return;
		}

		// cant star starboard messages
		if (await dbContext.StarredMessages.AnyAsync(starredMessage => starredMessage.StarboardMessageId == message.Id, ct))
		{
			return;
		}

		var minStarCount = await config.GetMinStarboardReactions(ct);
		var actualStarCount = message.Reactions[StarboardUtil.StarEmoji].ReactionCount;

		if (await StarboardUtil.GetStarredMessageByMessageId(dbContext, message.Id, ct) is { } starredMessage)
		{
			await StarboardUtil.UpdateStarredMessageStarCount(client, starredMessage, actualStarCount, ct);
		}
		else
		{
			// do this check only here because if a message is already on starboard, it should still be updated
			if (minStarCount > actualStarCount) return;

			var starboardMessage = await starboardChannel.SendMessageAsync(
				text: StarboardUtil.FormatStarboardMessageContent(actualStarCount, message.Channel.Id),
				allowedMentions: AllowedMentions.None,
				embed: BuildEmbed(message)
			);

			_ = await dbContext.AddAsync(StarredMessage.Create(
					messageId: message.Id,
					channelId: message.Channel.Id,
					starboardMessageId: starboardMessage.Id,
					starboardChannelId: starboardChannelId), ct);

			_ = await dbContext.SaveChangesAsync(ct);
		}
	}

	private static Embed BuildEmbed(IMessage message) =>
		new EmbedBuilder()
			.WithAuthor(message.Author)
			.WithDescription(message.Content)
			.WithFields(
				new EmbedFieldBuilder()
					.WithName(Format.Bold("Source"))
					.WithValue(Format.Url("Jump!", message.GetJumpUrl()))
			)
			.WithColor(0xffcc00)
			.WithFooter(builder => builder.WithText(message.Id.ToString(CultureInfo.InvariantCulture)))
			.Build();
}
