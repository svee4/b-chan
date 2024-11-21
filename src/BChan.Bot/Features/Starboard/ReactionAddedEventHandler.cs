using System.Globalization;
using System.Text;
using BChan.Bot.Database;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord;
using Discord.WebSocket;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;

namespace BChan.Bot.Features.Starboard;

[Handler]
public static partial class ReactionAddedEventHandler
{
	private static readonly Emoji _starEmoji = Emoji.Parse(":star:");
	private static readonly Emoji _dizzyEmoji = Emoji.Parse(":dizzy:");
	private static readonly Emoji _sparklesEmoji = Emoji.Parse(":sparkles:");

	private static readonly Emoji[] _emojis =
	[
		_starEmoji,
		_dizzyEmoji,
		_sparklesEmoji,
	];

	private static async ValueTask HandleAsync(
		ReactionAddedEvent @event,
		BotConfigurationManager config,
		DiscordSocketClient client,
		AppDbContext dbContext,
		CancellationToken ct)
	{
		Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

		var message = await @event.Message.GetOrDownloadAsync();

		var minStarCount = await config.GetMinStarboardReactions(ct);
		var actualStarCount = message.Reactions[_starEmoji].ReactionCount;

		var starboardChannelId = await config.GetStarboardChannelId(ct);
		if (starboardChannelId == null) return;

		var starboardChannel = client.Guilds.Single()
			.TextChannels.First(channel => channel.Id == starboardChannelId.Value);
		if (starboardChannel == null) return;

		if (minStarCount > actualStarCount)
		{
			Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
			return;
		}

		Console.WriteLine("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC");

		if (await GetStarredMessageById(dbContext, message.Id, ct) != null)
		{
			Console.WriteLine("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");

			await UpdateMessageStarCount(dbContext, client, config, message.Id, actualStarCount, ct);
		}
		else
		{
			Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");

			await starboardChannel.SendMessageAsync(
				text: FormatStarboardMessageContent(actualStarCount, message.Channel.Id),
				allowedMentions: AllowedMentions.None,
				embed: BuildEmbed(message)
			);
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
			.WithFooter(builder => { builder.WithText(message.Id.ToString(CultureInfo.InvariantCulture)); })
			.Build();

	private static async Task<StarredMessage?> GetStarredMessageById(
		AppDbContext ctx,
		ulong messageId,
		CancellationToken ct)
		=> await ctx.StarredMessages
			.Where(m => m.MessageId == messageId)
			.FirstAsync(ct);

	private static string FormatStarboardMessageContent(int starCount, ulong channelId)
	{
		return new StringBuilder()
			.AppendJoin(' ', (object[])
			[
				_emojis[Random.Shared.Next(_emojis.Length)],
				Format.Bold(starCount.ToString(CultureInfo.InvariantCulture)),
				$"<#{channelId.ToString(CultureInfo.InvariantCulture)}>",
			])
			.ToString();
	}

	private static async Task UpdateMessageStarCount(
		AppDbContext ctx,
		DiscordSocketClient client,
		BotConfigurationManager config,
		ulong starredMessageId,
		int newStarCount,
		CancellationToken ct)
	{
		StarredMessage starredMessage = await GetStarredMessageById(ctx, starredMessageId, ct)
		                                ?? throw new InvalidOperationException();

		var starboardChannelId = await config.GetStarboardChannelId(ct);
		if (starboardChannelId == null) return;

		var starboardChannel = await client.GetChannelAsync(starboardChannelId.Value,
			new RequestOptions { CancelToken = ct });

		if (starboardChannel is ITextChannel textChannel)
		{
			await textChannel.ModifyMessageAsync(starredMessage.StarboardMessageId,
				m => { m.Content = FormatStarboardMessageContent(newStarCount, starredMessageId); });
		}
	}
}
