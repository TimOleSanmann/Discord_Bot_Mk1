using Discord.WebSocket;
using System;

namespace Discord_Bot_Mk1
{
    class Program
    {
        static void Main(string[] args)
        {
            BotManager botManager = new BotManager();
            botManager.RunBot().GetAwaiter().GetResult();
        }
    }
}
