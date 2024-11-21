using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Bot.Database;

public sealed class StarredMessage : IEntityTypeConfiguration<StarredMessage>
{
	public int Id { get; private set; }

	public ulong MessageId { get; private init; }

	public ulong StarboardMessageId { get; private init; }

	public void Configure(EntityTypeBuilder<StarredMessage> builder) { }
}
