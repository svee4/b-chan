namespace BChan.Bot.Infra;

public interface IScopedServiceAccessor<out TService>
{
	IScopedServiceOwner<TService> CreateScope();
}

public interface IScopedServiceOwner<out TService> : IDisposable
{
	TService Service { get; }
}

public sealed class ScopedServiceAccessor<TService>(IServiceScopeFactory factory)
	: IScopedServiceAccessor<TService> where TService : class
{
	private readonly IServiceScopeFactory _factory = factory;

	public IScopedServiceOwner<TService> CreateScope()
	{
		var scope = _factory.CreateScope();
		var service = scope.ServiceProvider.GetRequiredService<TService>();
		return new ScopedServiceOwner<TService>(service, scope);
	}
}

public readonly struct ScopedServiceOwner<TService>(TService service, IServiceScope scope)
	: IScopedServiceOwner<TService>
{
	private readonly IServiceScope _scope = scope;

	public TService Service { get; } = service;

	public void Dispose() => _scope.Dispose();
}
