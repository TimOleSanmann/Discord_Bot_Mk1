using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot_Mk1
{
    public class TestCommands : ModuleBase<SocketCommandContext>
    {
        [Command("joke")]
        public async Task Ping()
        {
            ChuckNorrisApiHandler chuckNorrisApiHandler = new ChuckNorrisApiHandler();
            string joke = await chuckNorrisApiHandler.GetJoke();
            await Context.Channel.SendMessageAsync(joke);
            var test = await Context.User.CreateDMChannelAsync();
            await test.SendMessageAsync("So, you like jokes? Of Course! You are a joke.");

            var builder = new ComponentBuilder()
                          .WithButton("Link Button", "TheID");
            await ReplyAsync("Here is a Button!", components: builder.Build());

            builder = new ComponentBuilder()
                          .WithButton(label: "Test", style: ButtonStyle.Link, url: "https://www.youtube.com/watch?v=-MJi7T4lX80");
            await ReplyAsync("Here is a Button!", components: builder.Build());

        }

       
    }
}