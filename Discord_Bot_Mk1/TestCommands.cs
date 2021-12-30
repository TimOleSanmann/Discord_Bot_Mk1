using Discord.Commands;
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
        }
    }
}
