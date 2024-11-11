using BChan.Worker.Handlers.Events;
using Immediate.Handlers.Shared;

namespace BChan.Worker.Handlers;

[Handler]
public static partial class TestHandler
{
	private static ValueTask HandleAsync(
		UserVoiceStateUpdatedEvent @event,
		ILogger<TestHandler.Handler> logger,
		CancellationToken token)
	{
		logger.LogInformation("TestHandler called");
		return default;
	}
}
