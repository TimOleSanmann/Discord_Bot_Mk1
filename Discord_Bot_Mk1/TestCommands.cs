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
            await Context.Channel.SendMessageAsync(Context.Channel.Name);
            var user = Context.User as SocketGuildUser;
            foreach(var role in user.Roles.ToList())
            {
                await Context.Channel.SendMessageAsync(role.Name);
            }
            


            await Context.Channel.SendMessageAsync(joke);

            var test = await Context.User.CreateDMChannelAsync();
            await test.SendMessageAsync("So, you like jokes? Of Course! You are a joke.");

            var builder = new ComponentBuilder()
                          .WithButton("Link Button", "TheID");
            await ReplyAsync("Here is a Button!", components: builder.Build());

            builder = new ComponentBuilder()
                          .WithButton(label: "Test", style: ButtonStyle.Link, url: "https://www.youtube.com/watch?v=-MJi7T4lX80");
            await ReplyAsync("Here is a Button!", components: builder.Build());

            var menueBuilder = new SelectMenuBuilder()
                               .WithPlaceholder("Select an Option")
                               .WithCustomId("menu-1")
                               .WithMinValues(1)
                               .WithMaxValues(1)
                               .AddOption("Option A", "opt-a", "This is A")
                               .AddOption("Option B", "opt-b", "This is B");
            builder = new ComponentBuilder()
           .WithSelectMenu(menueBuilder);

            await ReplyAsync("Choose?", components: builder.Build());


            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = "Hello world!",
                Description = "I am a description set by initializer."
            };
            // Or with methods
            embed.AddField("Field title",
                "Field value. I also support [hyperlink markdown](https://example.com)!")
                .WithAuthor(Context.Client.CurrentUser)
                .WithFooter(footer => footer.Text = "I am a footer.")
                .WithColor(Color.Blue)
                .WithTitle("I overwrote \"Hello world!\"")
                .WithDescription("I am a description.")
                .WithUrl("https://example.com")
                .WithImageUrl("https://static.wikia.nocookie.net/poke5forum/images/6/60/028_Pikachu_%26_Zachary_28_88_20150911143525422.jpg/revision/latest/scale-to-width-down/246?cb=20150911123651&path-prefix=de")
                .WithThumbnailUrl("https://static.wikia.nocookie.net/poke5forum/images/6/60/028_Pikachu_%26_Zachary_28_88_20150911143525422.jpg/revision/latest/scale-to-width-down/246?cb=20150911123651&path-prefix=de")
                .WithCurrentTimestamp();

            //Your embed needs to be built before it is able to be sent
            await ReplyAsync(embed: embed.Build());

        }

       
    }
}