using System.Diagnostics.CodeAnalysis;

namespace BChan.Bot.Infra;

public sealed class ScopedServiceAccessor<TService>(IServiceScopeFactory factory) where TService : class
{
	private readonly IServiceScopeFactory _factory = factory;

	public ScopedServiceOwner CreateScope()
	{
		var scope = _factory.CreateScope();
		return new ScopedServiceOwner(scope.ServiceProvider.GetRequiredService<TService>(), scope);
	}

	[SuppressMessage("", "CA1034:Nested types should not be visible", Justification = "It just makes sense")]
	public readonly struct ScopedServiceOwner(TService service, IServiceScope scope) : IDisposable
	{
		private readonly IServiceScope _scope = scope;

		public TService Service { get; } = service;

		public void Dispose() => _scope.Dispose();
	}
}
