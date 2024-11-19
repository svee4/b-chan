# B-chan discord bot
Fun discord bot

# Developing
- Install .NET 8 or newer SDK
- Have a Discord bot ready to go
- Have a Postgres server ready to go
- Set the required configuration values
- Run the bot with `dotnet run` or your favourite IDE

## Required configuration:
Required configuration values are:
1. `BChan:DiscordBotToken` (string)
2. `BChan:DiscordGuildId` (ulong)
3. `BChan:DbConnectionString` (Postgres connection string)

The recommended method for handling configuration in development is `user-secrets`.
For example: 
- `cd src/BChan.Bot`
- `dotnet user-secrets set "BChan:DiscordBotToken" "MyBotToken"`

## Database changes
Updating database models requires creating a migration.
After updating the models under `src/BChan.Bot/Database`, create a new migration by running 
`dotnet ef migrations add "My migration name"`. The migration will be automatically applied at startup.
