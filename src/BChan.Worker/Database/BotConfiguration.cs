using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BChan.Worker.Database;

public sealed class BotConfiguration : IEntityTypeConfiguration<BotConfiguration>
{
	public int Id { get; private set; } // always 1... right ?

	public IList<ulong> AutoRolesIds { get; private set; } = null!;

	public static BotConfiguration CreateDefault() => new BotConfiguration()
	{
		AutoRolesIds = []
	};

	public void Configure(EntityTypeBuilder<BotConfiguration> builder) { }
}
