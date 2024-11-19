using System.Diagnostics;
using Discord;

namespace BChan.Bot.Infra;

public sealed class DiscordNetLogger(ILogger<DiscordNetLogger> logger)
{
	private readonly ILogger<DiscordNetLogger> _logger = logger;

	public Task Log(LogMessage message)
	{
		var logLevel = message.Severity switch
		{
			LogSeverity.Critical => LogLevel.Critical,
			LogSeverity.Error => LogLevel.Error,
			LogSeverity.Warning => LogLevel.Warning,
			LogSeverity.Info => LogLevel.Information,
			LogSeverity.Verbose => LogLevel.Debug,
			LogSeverity.Debug => LogLevel.Debug,
			_ => throw new UnreachableException(),
		};

		_logger.Log(logLevel, message.Exception, "{Source}: {Message}", message.Source, message.Message);

		return Task.CompletedTask;
	}
}
