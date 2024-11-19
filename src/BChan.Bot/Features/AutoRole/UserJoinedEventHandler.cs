using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Immediate.Handlers.Shared;

namespace BChan.Worker.Features.AutoRole;

[Handler]
public static partial class UserJoinedEventHandler
{
	private static async ValueTask HandleAsync(
		UserJoinedEvent @event,
		BotConfigurationManager manager,
		CancellationToken token)
	{
		var roles = await manager.GetAutoRoles(token);

		if (roles.Count > 0)
		{
			await @event.User.AddRolesAsync(roles, new Discord.RequestOptions
			{
				AuditLogReason = "AutoRole"
			});
		}
	}
}
