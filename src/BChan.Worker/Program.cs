using BChan.Worker;
using BChan.Worker.Database;
using BChan.Worker.Features.Test;
using BChan.Worker.Infra;
using BChan.Worker.Infra.DiscordEvents;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;

#pragma warning disable IDE0058 // Expression value is never used

var builder = Host.CreateApplicationBuilder(args);

if (builder.Environment.IsDevelopment())
{
	builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.Configure<BChanWorkerConfiguration>(builder.Configuration.GetSection(BChanWorkerConfiguration.Section));

builder.Services.AddNpgsql<AppDbContext>(
	builder.Configuration.GetSection("BChan").Get<BChanWorkerConfiguration>()!.DbConnectionString);

builder.Services.AddSingleton(typeof(ScopedServiceAccessor<>));

AddDiscordServices(builder);

builder.Services.AddHostedService<WorkerService>();
builder.Services.AddHostedService<EventPublisher>();

builder.Services.AddScoped<BotConfigurationManager>();
builder.Services.AddScoped<TestService>();

builder.Services.AddHandlers();


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
		new DiscordSocketConfig()
		{
			LogLevel = Discord.LogSeverity.Debug,
			GatewayIntents = Discord.GatewayIntents.AllUnprivileged | Discord.GatewayIntents.GuildMembers
		}));

	builder.Services.AddSingleton(_ => new CommandService(
		new CommandServiceConfig()
		{
			LogLevel = Discord.LogSeverity.Debug
		}));

	builder.Services.AddSingleton(sp => new InteractionService(
		sp.GetRequiredService<DiscordSocketClient>().Rest,
		new InteractionServiceConfig()
		{
			LogLevel = Discord.LogSeverity.Debug,
			AutoServiceScopes = true
		}));
}

static async Task SetupDatabase(AppDbContext dbContext)
{
	// we migrate automatically cuz we are lazy
	await Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.MigrateAsync(dbContext.Database);

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
