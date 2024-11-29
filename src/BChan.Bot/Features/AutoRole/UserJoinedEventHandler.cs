using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;

namespace BChan.Bot.Features.AutoRole;

public sealed class UserJoinedEventHandler(BotConfigurationManager manager) : IEventHandler<UserJoinedEvent>
{
	public async Task Handle(UserJoinedEvent @event, CancellationToken token)
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
