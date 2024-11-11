using BChan.Worker.Infra.DiscordEvents;
using Immediate.Handlers.Shared;

namespace BChan.Worker.Features.Test;

[Handler]
public static partial class TestEventConsumer
{
	private static ValueTask HandleAsync(
		UserVoiceStateUpdatedEvent @event, // event to listen for
		TestService service, // random thing to inject from di
		CancellationToken token) // last parameter is always cancellationtoken
	{
		service.DoServiceThing();
		return default;
	}
}
