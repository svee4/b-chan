# B-chan discord bot
Fun discord bot

# Developing
- Install .NET 8 or newer SDK
- Have a discord bot ready to go
- Set the required configuration values
- Run the bot with `dotnet run` or your favourite IDE

## Required configuration:
Required configuration values are:
1. `BChan:DiscordBotToken` (string)
2. `BChan:DiscordGuildId` (ulong)
3. `BChan:DbConnectionString` (Postgres connection string)

The recommended method for handling configuration in development is `user-secrets`.
For example: 
- `cd src/BChan.Worker`
- `dotnet user-secrets set "BChan:DiscordBotToken" "MyBotToken"`
