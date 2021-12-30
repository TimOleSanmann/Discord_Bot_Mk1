using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Discord_Bot_Mk1
{
    public class ChuckNorrisApiHandler
    {
        static readonly HttpClient httpClient = new HttpClient();
        public async Task<string> GetJoke()
        {
            Joke joke = new Joke();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
                responseMessage.EnsureSuccessStatusCode();
                joke = JsonConvert.DeserializeObject<Joke>(await responseMessage.Content.ReadAsStringAsync());
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return joke.value;
        }
    }
}
