
namespace BChan.Worker;

public sealed class BChanWorkerConfiguration
{
	public const string Section = "BChan";

	public required string DiscordBotToken { get; set; }
	public required ulong DiscordGuildId { get; set; }
}
