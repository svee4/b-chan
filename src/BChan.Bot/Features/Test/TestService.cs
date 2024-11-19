namespace BChan.Bot.Features.Test;


// service class so that TestCommand and TestEventConsumer dont duplicate code
public sealed class TestService
{
	private readonly ILogger<TestService> _logger;

	public TestService(ILogger<TestService> logger)
	{
		Console.WriteLine("TestService constructor");
		_logger = logger;
	}

	public void DoServiceThing()
	{
		_logger.LogInformation("Doing test service thing");
	}
}
