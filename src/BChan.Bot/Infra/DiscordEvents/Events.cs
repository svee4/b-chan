using Discord.WebSocket;

namespace BChan.Bot.Infra.DiscordEvents;

public sealed record UserVoiceStateUpdatedEvent(SocketUser User, SocketVoiceState State1, SocketVoiceState State2);
public sealed record UserJoinedEvent(SocketGuildUser User);