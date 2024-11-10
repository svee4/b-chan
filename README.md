# B-chan discord bot
Fun discord bot

# Developing
- Install .NET 8 or newer SDK
- Have a discord bot ready to go
- Set the required configuration values for BChan.Worker:
    - BChan:DiscordBotToken (string)
    - BChan:DiscordGuildId (ulong)
- Run the bot with `dotnet run` or your favourite IDE

#### Example configuration setup:
1. `cd ./src/BChan.Worker`
2. `dotnet user-secrets set "BChan:DiscordBotToken" MyBotToken`
3. `dotnet user-secrets set "BChan:DiscordGuildId" MyGuildId`
