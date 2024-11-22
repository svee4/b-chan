using Discord;
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
		_socketClient.ReactionAdded += ReactionAdded;
		_socketClient.ReactionRemoved += ReactionRemoved;
		_socketClient.MessageDeleted += MessageDeleted;

		_logger.LogInformation("Started");
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Stopping");

		_socketClient.UserVoiceStateUpdated -= UserVoiceStateUpdated;
		_socketClient.UserJoined -= UserJoined;
		_socketClient.ReactionAdded -= ReactionAdded;
		_socketClient.ReactionRemoved -= ReactionRemoved;
		_socketClient.MessageDeleted -= MessageDeleted;

		_logger.LogInformation("Stopped");
		return Task.CompletedTask;
	}


	private Task UserVoiceStateUpdated(SocketUser user, SocketVoiceState what1, SocketVoiceState what2) =>
		PublishEvent(new UserVoiceStateUpdatedEvent(user, what1, what2));

	private Task UserJoined(SocketGuildUser arg) =>
		PublishEvent(new UserJoinedEvent(arg));

	private Task ReactionAdded(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> channel, SocketReaction reaction) =>
		PublishEvent(new ReactionAddedEvent(message, channel, reaction));

	private Task ReactionRemoved(Cacheable<IUserMessage, ulong> message, Cacheable<IMessageChannel, ulong> channel, SocketReaction reaction) =>
		PublishEvent(new ReactionRemovedEvent(message, channel, reaction));

	private Task MessageDeleted(Cacheable<IMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2) =>
		PublishEvent(new MessageDeletedEvent(arg1, arg2));


	// returns a task only because the event handlers need to return task and this makes them able to be oneliners
	private Task PublishEvent<TEvent>(TEvent @event)
	{
		if (_logger.IsEnabled(LogLevel.Debug))
		{
			_logger.LogDebug("Publishing event '{Type}'", typeof(TEvent).FullName);
		}

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
