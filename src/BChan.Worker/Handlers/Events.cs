using Discord.WebSocket;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace BChan.Worker.Handlers.Events;
#pragma warning restore IDE0130 // Namespace does not match folder structure


public sealed record UserVoiceStateUpdatedEvent(SocketUser User, SocketVoiceState State1, SocketVoiceState State2);
