using BChan.Worker.Infra;
using BChan.Worker.Infra.DiscordEvents;
using Immediate.Handlers.Shared;

namespace BChan.Worker.Features.Test;

[Handler]
public static partial class TestEventConsumer
{
	private static async ValueTask HandleAsync(
		UserVoiceStateUpdatedEvent @event, // event to listen for
		TestService service, // random thing to inject from di
		BotConfigurationManager manager, // another random thing to inject from di
		CancellationToken token) // last parameter is always cancellationtoken
	{
		await Task.Delay(50, token);
		service.DoServiceThing();
		var roles = await manager.GetAutoRoles(token);
	}
}
