using System.Globalization;
using System.Text;
using BChan.Bot.Database;
using BChan.Bot.Infra;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;

namespace BChan.Bot.Features.Starboard;

public static class StarboardUtil
{
	public static readonly Emoji StarEmoji = Emoji.Parse(":star:");
	public static readonly Emoji DizzyEmoji = Emoji.Parse(":dizzy:");
	public static readonly Emoji SparklesEmoji = Emoji.Parse(":sparkles:");

	public static readonly Emoji[] Emojis =
	[
		StarEmoji,
		DizzyEmoji,
		SparklesEmoji,
	];

	public static async Task<StarredMessage?> GetStarredMessageById(
		AppDbContext dbContext,
		ulong messageId,
		CancellationToken ct)
		=> await dbContext.StarredMessages
			.Where(m => m.MessageId == messageId)
			.FirstOrDefaultAsync(ct);

	public static string FormatStarboardMessageContent(int starCount, ulong channelId)
		=> new StringBuilder()
			.AppendJoin(' ', (object[])
			[
				Emojis[Random.Shared.Next(Emojis.Length)],
				Format.Bold(starCount.ToString(CultureInfo.InvariantCulture)),
				$"<#{channelId.ToString(CultureInfo.InvariantCulture)}>",
			])
			.ToString();

	public static async Task UpdateStarCountWithStarredMessage(
		DiscordSocketClient client,
		BotConfigurationManager config,
		StarredMessage starredMessage,
		int newStarCount,
		CancellationToken ct)
	{
		var starboardChannelId = await config.GetStarboardChannelId(ct);
		if (starboardChannelId == null) return;

		var starboardChannel = await client.GetChannelAsync(starboardChannelId.Value,
			new RequestOptions { CancelToken = ct });

		if (starboardChannel is ITextChannel textChannel)
		{
			await textChannel.ModifyMessageAsync(starredMessage.StarboardMessageId,
				m => { m.Content = FormatStarboardMessageContent(newStarCount, starredMessage.MessageId); });
		}
	}

	public static async Task UpdateStarCountForMessage(
		AppDbContext dbContext,
		DiscordSocketClient client,
		BotConfigurationManager config,
		ulong starredMessageId,
		int newStarCount,
		CancellationToken ct)
	{
		var starredMessage = await GetStarredMessageById(dbContext, starredMessageId, ct)
		                     ?? throw new InvalidOperationException();

		await UpdateStarCountWithStarredMessage(client, config, starredMessage, newStarCount, ct);
	}
}
