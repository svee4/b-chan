using BChan.Worker.Handlers.Events;
using Discord.WebSocket;
using Immediate.Handlers.Shared;

namespace BChan.Worker.Handlers;

public sealed class DiscordEventListener(
	DiscordSocketClient socketClient,
	IServiceProvider serviceProvider,
	ILogger<DiscordEventListener> logger
	) : IHostedService
{

	private readonly DiscordSocketClient _socketClient = socketClient;
	private readonly IServiceProvider _serviceProvider = serviceProvider;
	private readonly ILogger<DiscordEventListener> _logger = logger;

	public Task StartAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Starting");

		_socketClient.UserVoiceStateUpdated += UserVoiceStateUpdated;

		_logger.LogInformation("Started");
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Stopping");

		_socketClient.UserVoiceStateUpdated -= UserVoiceStateUpdated;

		_logger.LogInformation("Stopped");
		return Task.CompletedTask;
	}


	private async Task UserVoiceStateUpdated(SocketUser user, SocketVoiceState what1, SocketVoiceState what2) =>
		await InvokeHandlers(new UserVoiceStateUpdatedEvent(user, what1, what2));


	private async Task InvokeHandlers<TEvent>(TEvent @event)
	{
		_logger.LogDebug("Invoking handlers for type '{Type}'", typeof(TEvent).FullName);

		using var scope = _serviceProvider.CreateScope();
		var handlers = scope.ServiceProvider.GetRequiredService<IEnumerable<IHandler<TEvent, ValueTuple>>>();
		foreach (var handler in handlers)
		{
			_ = await handler.HandleAsync(@event);
		}
	}
}
