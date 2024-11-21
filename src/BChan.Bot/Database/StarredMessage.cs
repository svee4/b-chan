using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Bot.Database;

public sealed class StarredMessage(ulong messageId, ulong starboardMessageId) : IEntityTypeConfiguration<StarredMessage>
{
	public int Id { get; private set; }

	public ulong MessageId { get; private init; } = messageId;

	public ulong StarboardMessageId { get; private init; } = starboardMessageId;

	public void Configure(EntityTypeBuilder<StarredMessage> builder) { }
}
