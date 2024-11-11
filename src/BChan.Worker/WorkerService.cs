using System.Diagnostics;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Options;

namespace BChan.Worker;

public class WorkerService(
	DiscordSocketClient socketClient,
	CommandService commandService,
	InteractionService interactionService,
	IOptions<BChanWorkerConfiguration> configurationOptions,
	IServiceProvider serviceProvider,
	ILogger<WorkerService> logger) : IHostedService
{

	private readonly DiscordSocketClient _socketClient = socketClient;
	private readonly CommandService _commandService = commandService;
	private readonly InteractionService _interactionService = interactionService;
	private readonly BChanWorkerConfiguration _configuration = configurationOptions.Value;
	private readonly IServiceProvider _serviceProvider = serviceProvider;
	private readonly ILogger<WorkerService> _logger = logger;

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		_socketClient.Log += HandleDiscordNetLogMessage;
		_commandService.Log += HandleDiscordNetLogMessage;
		_interactionService.Log += HandleDiscordNetLogMessage;

		await AddModules();
		await StartClient();

		_socketClient.InteractionCreated += OnSocketClientInteractionCreated;
		await _interactionService.RegisterCommandsToGuildAsync(_configuration.DiscordGuildId, deleteMissing: true);

		return;

		async Task AddModules()
		{
			var commands = await _commandService.AddModulesAsync(typeof(WorkerService).Assembly, _serviceProvider);

			var anyCommands = false;
			foreach (var module in commands)
			{
				anyCommands = true;
				_logger.LogInformation("Added command module {ModuleName} with commands {Commands}",
					module.Name,
					module.Commands.Select(c => c.Name));
			}

			if (!anyCommands)
			{
				_logger.LogInformation("No commands registered");
			}

			// for some reason, AddModulesAsync calls the constructors of the modules,
			// which means to use scoped dependencies you need to create a scope for it.
			// in actual use, the modules are scoped
			using var scope = _serviceProvider.CreateScope();
			var interactions = await _interactionService.AddModulesAsync(typeof(WorkerService).Assembly, scope.ServiceProvider);

			var anyInteractions = false;
			foreach (var module in interactions)
			{
				anyInteractions = true;
				_logger.LogInformation("Added interaction module {ModuleName} with commands {Interactions}",
					module.Name,
					module.SlashCommands.Select(c => c.Name));
			}

			if (!anyInteractions)
			{
				_logger.LogInformation("No interactions registered");
			}
		}

		async Task StartClient()
		{
			var onReadySource = new TaskCompletionSource();
			_socketClient.Ready += OnReady;

			await _socketClient.LoginAsync(TokenType.Bot, _configuration.DiscordBotToken);
			await _socketClient.StartAsync();

			await onReadySource.Task;
			_socketClient.Ready -= OnReady;

			Task OnReady()
			{
				onReadySource.SetResult();
				return Task.CompletedTask;
			}
		}
	}

	private async Task OnSocketClientInteractionCreated(SocketInteraction interaction) =>
		// this delegates interactions to the actual InteractionService
		await _interactionService.ExecuteCommandAsync(new SocketInteractionContext(_socketClient, interaction), _serviceProvider);

	private Task HandleDiscordNetLogMessage(LogMessage message)
	{
		_logger.Log(
			logLevel: message.Severity switch
			{
				Discord.LogSeverity.Critical => LogLevel.Critical,
				Discord.LogSeverity.Error => LogLevel.Error,
				Discord.LogSeverity.Warning => LogLevel.Warning,
				Discord.LogSeverity.Info => LogLevel.Information,
				Discord.LogSeverity.Verbose => LogLevel.Debug,
				Discord.LogSeverity.Debug => LogLevel.Debug,
				_ => throw new UnreachableException(),
			},
			message: message.ToString());

		return Task.CompletedTask;
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("Stopping");

		_socketClient.InteractionCreated -= OnSocketClientInteractionCreated;
		_socketClient.Log -= HandleDiscordNetLogMessage;
		_commandService.Log -= HandleDiscordNetLogMessage;
		_interactionService.Log -= HandleDiscordNetLogMessage;

		await _socketClient.StopAsync();
		_interactionService.Dispose();
		await _socketClient.DisposeAsync();

		_logger.LogInformation("Stopped");
	}
}
