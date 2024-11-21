using Discord;
using Discord.WebSocket;

namespace BChan.Bot.Infra.DiscordEvents;

public sealed record UserVoiceStateUpdatedEvent(SocketUser User, SocketVoiceState State1, SocketVoiceState State2);

public sealed record UserJoinedEvent(SocketGuildUser User);

public sealed record ReactionAddedEvent(
	Cacheable<IUserMessage, ulong> Message,
	Cacheable<IMessageChannel, ulong> Channel,
	SocketReaction Reaction);

public sealed record ReactionRemovedEvent(
	Cacheable<IUserMessage, ulong> Message,
	Cacheable<IMessageChannel, ulong> Channel,
	SocketReaction Reaction)
{
	public object Reactions { get; set; }
}
