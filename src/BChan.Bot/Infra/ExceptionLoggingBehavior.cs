using Immediate.Handlers.Shared;

namespace BChan.Bot.Infra;

public sealed class ExceptionLoggingBehavior<TRequest, TResponse>(ILogger<ExceptionLoggingBehavior<TRequest, TResponse>> logger)
	: Behavior<TRequest, TResponse>
{
	private readonly ILogger _logger = logger;

	public override async ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken)
	{
		try
		{
			return await Next(request, cancellationToken);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Uncaught exception in pipeline of {Handler}", HandlerType);
			throw;
		}
	}
}
