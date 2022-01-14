using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot_Mk1
{
    public class Secret
    {
        
        public static string GetToken()
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("secrets.json")
                        .Build();
            var secret = config.GetSection("DiscordBotToken").Value;
            return secret;
        }
    }
}
