using System.Globalization;
using BChan.Bot.Database;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord;
using Discord.WebSocket;
using Immediate.Handlers.Shared;

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
		if (!@event.Reaction.Emote.Equals(StarboardUtil.StarEmoji)) return;

		var message = await @event.Message.GetOrDownloadAsync();

		var minStarCount = await config.GetMinStarboardReactions(ct);
		var actualStarCount = message.Reactions[StarboardUtil.StarEmoji].ReactionCount;
		if (minStarCount > actualStarCount) return;

		var starboardChannelId = await config.GetStarboardChannelId(ct);
		if (starboardChannelId == null) return;

		var starboardChannel = client.Guilds.Single()
			.TextChannels.First(channel => channel.Id == starboardChannelId.Value);
		if (starboardChannel == null) return;

		var starredMessage = await StarboardUtil.GetStarredMessageById(dbContext, message.Id, ct);
		if (starredMessage != null)
		{
			await StarboardUtil.UpdateStarCountWithStarredMessage(client, config, starredMessage, actualStarCount, ct);
		}
		else
		{
			var starboardMessage = await starboardChannel.SendMessageAsync(
				text: StarboardUtil.FormatStarboardMessageContent(actualStarCount, message.Channel.Id),
				allowedMentions: AllowedMentions.None,
				embed: BuildEmbed(message)
			);

			await dbContext.AddAsync(new StarredMessage(message.Id, starboardMessage.Id), ct);
			await dbContext.SaveChangesAsync(ct);
		}
	}

	private static Embed BuildEmbed(IMessage message)
		=> new EmbedBuilder()
			.WithAuthor(message.Author)
			.WithDescription(message.Content)
			.WithFields(
				new EmbedFieldBuilder()
					.WithName(Format.Bold("Source"))
					.WithValue(Format.Url("Jump!", message.GetJumpUrl()))
			)
			.WithColor(0xffcc00)
			.WithFooter(builder => { builder.WithText(message.Id.ToString(CultureInfo.InvariantCulture)); })
			.Build();
}
