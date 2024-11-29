using BChan.Bot.Features.Test;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
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
		_ = @event;
		await Task.Delay(50, token);
		service.DoServiceThing();
		_ = await manager.GetAutoRoles(token);
	}
}
