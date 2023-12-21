using Discord;
using Discord.WebSocket;

await RunDevBuddy();

async Task RunDevBuddy()
{
    try
    {
        var client = new DiscordSocketClient();
        await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("TOKEN"));
        await client.StartAsync();
        client.Ready += async () =>
        {
            var guild = client.GetGuild(Convert.ToUInt64(Environment.GetEnvironmentVariable("GUILD")));
            var channel = guild.GetTextChannel(Convert.ToUInt64(Environment.GetEnvironmentVariable("CHANNEL")));
            await channel.CreateThreadAsync("Tópico de teste");
            await client.DisposeAsync();
        };
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        throw;
    }
}

Console.WriteLine("Pressione qualquer tecla para parar a execução...");
Console.ReadKey();