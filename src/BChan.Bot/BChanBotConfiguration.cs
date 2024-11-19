namespace BChan.Bot;

public sealed class BChanBotConfiguration
{
	public const string Section = "BChan";

	public required string DiscordBotToken { get; set; }
	public required ulong DiscordGuildId { get; set; }
	public required string DbConnectionString { get; set; }
}
