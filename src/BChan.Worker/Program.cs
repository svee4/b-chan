using BChan.Worker;
using BChan.Worker.Features.Test;
using BChan.Worker.Infra.DiscordEvents;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;

#pragma warning disable IDE0058 // Expression value is never used

var builder = Host.CreateApplicationBuilder(args);

if (builder.Environment.IsDevelopment())
{
	builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.Configure<BChanWorkerConfiguration>(builder.Configuration.GetSection(BChanWorkerConfiguration.Section));

AddDiscordServices(builder);

builder.Services.AddHostedService<WorkerService>();
builder.Services.AddHostedService<EventPublisher>();

builder.Services.AddScoped<TestService>();

builder.Services.AddHandlers();

var host = builder.Build();
host.Run();


static void AddDiscordServices(HostApplicationBuilder builder)
{
	// TODO: actual configs

	builder.Services.AddSingleton(sp => new DiscordSocketClient(
		new DiscordSocketConfig()
		{
			LogLevel = Discord.LogSeverity.Debug,
		}));

	builder.Services.AddSingleton(sp => new CommandService(
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

#pragma warning restore IDE0058 // Expression value is never used
