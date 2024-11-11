using Discord.WebSocket;

namespace BChan.Worker.Infra.DiscordEvents;

public sealed record UserVoiceStateUpdatedEvent(SocketUser User, SocketVoiceState State1, SocketVoiceState State2);
