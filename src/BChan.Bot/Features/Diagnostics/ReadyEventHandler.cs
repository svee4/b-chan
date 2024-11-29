using BChan.Bot.Infra.DiscordEvents;
using Immediate.Handlers.Shared;

namespace BChan.Bot.Features.Diagnostics;

[Handler]
public static partial class ReadyEventHandler
{
	public static ValueTask HandleAsync(ReadyEvent _)
	{
		DiagnosticsModule.ReadyTimestamp = DateTime.UtcNow;
		return ValueTask.CompletedTask;
	}
}
