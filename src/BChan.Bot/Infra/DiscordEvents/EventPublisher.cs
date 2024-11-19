using Discord.WebSocket;
using Immediate.Handlers.Shared;

namespace BChan.Bot.Infra.DiscordEvents;

public sealed class EventPublisher(
	DiscordSocketClient socketClient,
	IServiceProvider serviceProvider,
	ILogger<EventPublisher> logger
	) : IHostedService
{

	private readonly DiscordSocketClient _socketClient = socketClient;
	private readonly IServiceProvider _serviceProvider = serviceProvider;
	private readonly ILogger<EventPublisher> _logger = logger;

	public Task StartAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Starting");

		_socketClient.UserVoiceStateUpdated += UserVoiceStateUpdated;
		_socketClient.UserJoined += UserJoined;

		_logger.LogInformation("Started");
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Stopping");

		_socketClient.UserVoiceStateUpdated -= UserVoiceStateUpdated;
		_socketClient.UserJoined -= UserJoined;

		_logger.LogInformation("Stopped");
		return Task.CompletedTask;
	}


	private Task UserVoiceStateUpdated(SocketUser user, SocketVoiceState what1, SocketVoiceState what2) =>
		PublishEvent(new UserVoiceStateUpdatedEvent(user, what1, what2));

	private Task UserJoined(SocketGuildUser arg) =>
		PublishEvent(new UserJoinedEvent(arg));


	// returns a task only because the event handlers need to return task and this makes them able to be oneliners
	private Task PublishEvent<TEvent>(TEvent @event)
	{
		_logger.LogDebug("Publishing event '{Type}'", typeof(TEvent).FullName);

		var handlers = _serviceProvider.GetService<IEnumerable<ScopedServiceAccessor<IHandler<TEvent, ValueTuple>>>>();

		foreach (var handler in handlers ?? [])
		{
			_ = Task.Run(async () =>
			{
				using var scopeOwner = handler.CreateScope();
				_ = await scopeOwner.Service.HandleAsync(@event);
			});
		}

		return Task.CompletedTask;
	}
}
