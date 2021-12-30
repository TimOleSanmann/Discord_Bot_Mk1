using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot_Mk1
{
    public class BotManager
    {
        public DiscordSocketClient BotClient;
        public CommandService Commands;
        public IServiceProvider ServiceProvider;
        public const string PREFIX = "$";

        public async Task RunBot()
        {
            Commands = new CommandService();
            ServiceProvider = ConfigureServices();
            BotClient = new DiscordSocketClient();
            await BotClient.LoginAsync(Discord.TokenType.Bot, Secret.GetToken());
            await BotClient.StartAsync();

            BotClient.Log += BotLog;
            Commands.Log += BotLog;
            BotClient.Ready += BotReady;

            await Task.Delay(-1);
        }

        public Task BotLog(LogMessage message)
        {
            Console.WriteLine("Bot: {0}", message);
            return Task.CompletedTask;
        }
        
        public async Task BotReady()
        {
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), ServiceProvider);
            await BotClient.SetGameAsync("Lernen einen Bot zu schreiben");
            BotClient.MessageReceived += ReceiveMessage;
        }

        public async Task ReceiveMessage(SocketMessage msg)
        {
            SocketUserMessage message = msg as SocketUserMessage;
            int commandPosition = 0;
            if (message.HasStringPrefix(PREFIX, ref commandPosition))
            {
                SocketCommandContext context = new SocketCommandContext(BotClient, message);
                IResult result = await Commands.ExecuteAsync(context, commandPosition, ServiceProvider);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        public IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                   .AddSingleton<TestCommands>()
                   .BuildServiceProvider();
        }
    }
}
