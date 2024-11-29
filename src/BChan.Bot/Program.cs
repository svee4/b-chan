using BChan.Bot;
using BChan.Bot.Database;
using BChan.Bot.Features.Test;
using BChan.Bot.Infra;
using BChan.Bot.Infra.DiscordEvents;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Serilog;

#pragma warning disable IDE0058 // Expression value is never used


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog((sp, logger) => logger.ReadFrom.Configuration(sp.GetRequiredService<IConfiguration>()));

if (builder.Environment.IsDevelopment())
{
	builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.Configure<BChanBotConfiguration>(builder.Configuration.GetSection(BChanBotConfiguration.Section));

builder.Services.AddNpgsql<AppDbContext>(
	builder.Configuration.GetSection("BChan").Get<BChanBotConfiguration>()!.DbConnectionString);

AddHandlers(builder.Services);
AddDiscordServices(builder);

builder.Services.AddHostedService<EventPublisher>(); // EventPublisher must be before WorkerService
builder.Services.AddHostedService<WorkerService>();

builder.Services.AddScoped<BotConfigurationManager>();
builder.Services.AddScoped<TestService>();
builder.Services.AddSingleton<DiscordNetLogger>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
	await SetupDatabase(scope.ServiceProvider.GetRequiredService<AppDbContext>());
}

await host.RunAsync();

static void AddDiscordServices(HostApplicationBuilder builder)
{
	// TODO: actual configs

	builder.Services.AddSingleton(_ => new DiscordSocketClient(
		new DiscordSocketConfig
		{
			LogLevel = Discord.LogSeverity.Debug,
			GatewayIntents = Discord.GatewayIntents.AllUnprivileged
							 | Discord.GatewayIntents.GuildMembers
							 | Discord.GatewayIntents.MessageContent
		}));

	builder.Services.AddSingleton(_ => new CommandService(
		new CommandServiceConfig { LogLevel = Discord.LogSeverity.Debug }));

	builder.Services.AddSingleton(sp => new InteractionService(
		sp.GetRequiredService<DiscordSocketClient>().Rest,
		new InteractionServiceConfig { LogLevel = Discord.LogSeverity.Debug, AutoServiceScopes = true }));
}

static void AddHandlers(IServiceCollection services)
{
	var types = typeof(Program).Assembly
		.GetTypes()
		.Select(type => (Type: type, Interface: type.GetInterface("BChan.Bot.Infra.DiscordEvents.IEventHandler`1")))
		.Where(tuple => tuple.Interface is not null);

	foreach (var (handlerType, handlerInterface) in types)
	{
		var eventType = handlerInterface!.GetGenericArguments().Single();
		var accessorImplType = typeof(ScopedServiceAccessor<>).MakeGenericType(handlerType);
		var accessorServiceType = typeof(IScopedServiceAccessor<>).MakeGenericType(handlerInterface);

		services.AddScoped(handlerType);
		services.AddSingleton(serviceType: accessorServiceType, implementationType: accessorImplType);
	}
}

static async Task SetupDatabase(AppDbContext dbContext)
{
	// we migrate automatically cuz we are lazy
	await RelationalDatabaseFacadeExtensions.MigrateAsync(dbContext.Database);

#pragma warning disable CS0618 // Type or member is obsolete

	if (await dbContext.BotConfiguration.FirstOrDefaultAsync() is null)
	{
		var defaultConfig = BotConfiguration.CreateDefault();
		await dbContext.BotConfiguration.AddAsync(defaultConfig);
		await dbContext.SaveChangesAsync();
	}

#pragma warning restore CS0618 // Type or member is obsolete
}

#pragma warning restore IDE0058 // Expression value is never used
