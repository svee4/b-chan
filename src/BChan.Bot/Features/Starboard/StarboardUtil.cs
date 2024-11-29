using BChan.Bot.Database;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace BChan.Bot.Features.Starboard;

public static class StarboardUtil
{
	public static Emoji StarEmoji { get; } = Emoji.Parse(":star:");
	public static Emoji DizzyEmoji { get; } = Emoji.Parse(":dizzy:");
	public static Emoji SparklesEmoji { get; } = Emoji.Parse(":sparkles:");

	public static IReadOnlyList<Emoji> Emojis { get; } =
	[
		StarEmoji,
		DizzyEmoji,
		SparklesEmoji,
	];

	public static async Task<StarredMessage?> GetStarredMessageByMessageId(
		AppDbContext dbContext,
		ulong messageId,
		CancellationToken ct) =>
		await dbContext.StarredMessages
			.Where(m => m.MessageId == messageId)
			.FirstOrDefaultAsync(ct);

	public static string FormatStarboardMessageContent(int starCount, ulong channelId) =>
		new StringBuilder()
			.AppendJoin(
				' ',
				(object[])[
					Emojis[Random.Shared.Next(Emojis.Count)],
					Format.Bold(starCount.ToString(CultureInfo.InvariantCulture)),
					$"<#{channelId.ToString(CultureInfo.InvariantCulture)}>",
				])
			.ToString();

	public static async Task UpdateStarredMessageStarCount(
		DiscordSocketClient client,
		StarredMessage starredMessage,
		int newStarCount,
		CancellationToken ct)
	{
		if (await client.GetChannelAsync(starredMessage.StarboardChannelId, new RequestOptions { CancelToken = ct })
			is ITextChannel textChannel)
		{
			_ = await textChannel.ModifyMessageAsync(
				messageId: starredMessage.StarboardMessageId,
				func: m => m.Content = FormatStarboardMessageContent(newStarCount, starredMessage.ChannelId),
				options: new RequestOptions { CancelToken = ct });
		}
	}
}
