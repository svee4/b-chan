namespace BChan.Bot.Infra.DiscordEvents;

public interface IEventHandler<TEvent>
{
	Task Handle(TEvent @event, CancellationToken token);
}
