using Discord.Interactions;

namespace BChan.Worker.Modules;

public sealed class TestModule : InteractionModuleBase
{
	[SlashCommand("test", "asdasd")]
	public async Task Test()
	{
		Console.WriteLine("Test");
		await RespondAsync("uwaa");
		Console.WriteLine("Test ended");
	}
}
