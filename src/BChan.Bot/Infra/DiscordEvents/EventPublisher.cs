using Discord.WebSocket;
using System.Diagnostics.CodeAnalysis;

namespace BChan.Bot.Infra.DiscordEvents;

public sealed partial class EventPublisher(
	DiscordSocketClient socketClient,
	IServiceProvider serviceProvider,
	ILogger<EventPublisher> logger
	) : IHostedService, IDisposable
{

	[SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "Not my job")]
	private readonly DiscordSocketClient _socketClient = socketClient;
	private readonly IServiceProvider _serviceProvider = serviceProvider;
	private readonly CancellationTokenSource _cancellationTokenSource = new();
	private readonly ILogger<EventPublisher> _logger = logger;

	public Task StartAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Starting");

		AddEventHandlers();

		_logger.LogInformation("Started");
		return Task.CompletedTask;
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Stopping");

		await _cancellationTokenSource.CancelAsync();

		RemoveEventHandlers();

		_logger.LogInformation("Stopped");
	}

	// returns a task only because the event handlers need to return task and this makes them able to be oneliners
	private Task PublishEvent<T>(T @event)
	{
		var accessors = _serviceProvider.GetServices<IScopedServiceAccessor<IEventHandler<T>>>();

		foreach (var accessor in accessors)
		{
			_ = Task.Run(async () =>
			{
				using var scope = accessor.CreateScope();
				try
				{
					await scope.Service.Handle(@event, _cancellationTokenSource.Token);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Uncaught exception in {Handler}", scope.Service.GetType());
				}
			});
		}

		return Task.CompletedTask;
	}

	public void Dispose() =>
		_cancellationTokenSource.Dispose();
}
