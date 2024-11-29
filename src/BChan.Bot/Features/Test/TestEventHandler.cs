using BChan.Bot.Infra.DiscordEvents;

namespace BChan.Bot.Features.Test;

public sealed class TestEventHandler(ILogger<TestEventHandler> logger) : IEventHandler<UserVoiceStateUpdatedEvent>
{
	public Task Handle(UserVoiceStateUpdatedEvent @event, CancellationToken token)
	{
		logger.LogInformation("IT WORKS");
		return Task.CompletedTask;
	}
}

public sealed class TestEventHandler2(ILogger<TestEventHandler2> logger) : IEventHandler<UserVoiceStateUpdatedEvent>
{
	public Task Handle(UserVoiceStateUpdatedEvent @event, CancellationToken token)
	{
		logger.LogInformation("IT WORKS22222");
		return Task.CompletedTask;
	}
}
