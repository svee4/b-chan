using BChan.Bot.Infra.DiscordEvents;

namespace BChan.Bot.Features.Diagnostics;

public sealed class ReadyEventHandler : IEventHandler<ReadyEvent>
{
	public Task Handle(ReadyEvent @event, CancellationToken token)
	{
		DiagnosticsModule.ReadyTimestamp = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}
