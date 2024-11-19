using Discord.Interactions;

namespace BChan.Bot.Features.Test;

public sealed class TestModule(TestService testService) : InteractionModuleBase
{
	private readonly TestService _testService = testService;

	[SlashCommand("test", "asdasd")]
	public async Task Test()
	{
		_testService.DoServiceThing();
		await RespondAsync("bwaa");
	}
}
