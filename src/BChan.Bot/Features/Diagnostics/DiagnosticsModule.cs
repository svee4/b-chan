using Discord.Interactions;
using Discord.WebSocket;
using System.Globalization;

namespace BChan.Bot.Features.Diagnostics;

[Group("diagnostics", "Ermm diagnostics")]
public sealed class DiagnosticsModule(DiscordSocketClient socketClient) : InteractionModuleBase
{
	private readonly DiscordSocketClient _socketClient = socketClient;

	public static DateTimeOffset ReadyTimestamp { get; set; }


	[SlashCommand("ping", "Get the bot's ping")]
	public async Task Ping() =>
		await RespondAsync($"{_socketClient.Latency}ms");

	[SlashCommand("uptime", "Get the bot's uptime")]
	public async Task Uptime() =>
		await RespondAsync((DateTimeOffset.UtcNow - ReadyTimestamp).ToString(@"dd\.hh\:mm\:ss", CultureInfo.InvariantCulture));
}
