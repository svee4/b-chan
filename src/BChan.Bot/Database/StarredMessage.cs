using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Bot.Database;

public sealed class StarredMessage : IEntityTypeConfiguration<StarredMessage>
{
	public int Id { get; private set; }

	public ulong MessageId { get; private set; }

	public ulong ChannelId { get; private set; }

	public ulong StarboardMessageId { get; private set; }

	// keep the starboard channel id cuz it might change
	public ulong StarboardChannelId { get; private set; }

	public static StarredMessage Create(
		ulong messageId,
		ulong channelId,
		ulong starboardMessageId,
		ulong starboardChannelId) => new()
		{
			MessageId = messageId,
			ChannelId = channelId,
			StarboardMessageId = starboardMessageId,
			StarboardChannelId = starboardChannelId
		};

	public void Configure(EntityTypeBuilder<StarredMessage> builder)
	{
		builder.HasIndex(model => model.MessageId);
		builder.HasIndex(model => model.StarboardMessageId);
	}
}
